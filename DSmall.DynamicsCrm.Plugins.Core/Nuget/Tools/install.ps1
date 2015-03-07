param($installPath, $toolsPath, $package, $project)
	$references = $project.Object.References | Where-Object { $_.Name -notlike "System*" -and $_.Name -notlike "Microsoft*" -and $_.Name -ne "mscorlib" }
	$references | ForEach-Object { 
		$referenceName = "*" + $_.Name + "*"
		$buildProject = @([Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName))[0]
		$toEdit = $buildProject.Xml.Items | Where-Object { $_.Include -like $referenceName }
		$metadataItems = $toEdit.Metadata | Where-Object { $_.Name -eq "ILMerge" }
		if($metadataItems.Count -lt 1) {
			$toEdit.AddMetaData("AssemblyName", $_.Name + ".dll")
			$toEdit.AddMetaData("ILMerge", "true")
		}
	}
	$project.Save()

	$AssemblyKeyFileName = $project.Properties.Item("AssemblyOriginatorKeyFile").Value;
	$item = $project.ProjectItems.Item($AssemblyKeyFileName)
	$item.Properties.Item("CopyToOutputDirectory").Value = 1

	$targetsFile = [System.IO.Path]::Combine($toolsPath, $package.Id + '.targets')
	$ILMergeFileLocation = [System.IO.Path]::Combine($toolsPath, 'ILMerge.exe')
 
	Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

	$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
 
	$projectUri = new-object Uri($project.FullName, [System.UriKind]::Absolute)
	$targetUri = new-object Uri($targetsFile, [System.UriKind]::Absolute)
	$relativePath = [System.Uri]::UnescapeDataString($projectUri.MakeRelativeUri($targetUri).ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)

	$ILMergeFileLocationUri = new-object Uri($ILMergeFileLocation, [System.UriKind]::Absolute)
	$ILMergeFileLocationRelativePath = [System.Uri]::UnescapeDataString($projectUri.MakeRelativeUri($ILMergeFileLocationUri).ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)
 
	$import = $msbuild.Xml.AddImport($relativePath)
	$import.Condition = "Exists('$relativePath')"
	
	$TargetFramework = """v4," + $env:ProgramFiles + "\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0"""

	$target = $msbuild.Xml.AddTarget("DSmallAfterBuild")
	$target.AfterTargets = "AfterBuild"

	$project.Save()

	$commandText = """$ILMergeFileLocationRelativePath"" /targetplatform:$TargetFramework /keyfile:$AssemblyKeyFileName `$(AdditionalParameters) /out:""`$(OutputFileName)"" ""`$(MainAssembly)"" @(AssembliesToMerge->'""`$(TargetDir)%(AssemblyName)""', ' ')"
	$task = $target.AddTask("Exec")
	$task.SetParameter("Command", $commandText)

	$message = $target.AddTask("Message")
	$message.SetParameter("Text", $commandText)
	$message.SetParameter("Importance", "High")

	$project.Save()

	$xml = [XML] (gc $project.FullName)
	$nsmgr = New-Object System.Xml.XmlNamespaceManager -ArgumentList $xml.NameTable
	$nsmgr.AddNamespace('msbld', "http://schemas.microsoft.com/developer/msbuild/2003")

	$node = $xml.Project.SelectSingleNode("//msbld:Target[@Name='DSmallAfterBuild']", $nsmgr)
	$afterBuildExecuteScript = $node.InnerXml

	$fileRetrieval = $xml.CreateElement("FileRetrieval", $xml.Project.GetAttribute("xmlns"))
	$itemGroup = $xml.CreateElement("ItemGroup", $xml.Project.GetAttribute("xmlns"))
	$assembliesToMerge = $xml.CreateElement("AssembliesToMerge", $xml.Project.GetAttribute("xmlns"))
	$itemGroup.AppendChild($assembliesToMerge)
	$fileRetrieval.AppendChild($itemGroup)

	$includeAttribute = $xml.CreateAttribute("Include")
	$includeAttribute.Value = "@(ReferencePath)"
	$assembliesToMerge.Attributes.Append($includeAttribute)

	$conditionAttribute = $xml.CreateAttribute("Condition")
	$conditionAttribute.Value = "'%(ReferencePath.ILMerge)'=='true'"
	$assembliesToMerge.Attributes.Append($conditionAttribute)

	$node.InnerXml = $fileRetrieval.InnerXml + $afterBuildExecuteScript

	$xml.Save($project.FullName)