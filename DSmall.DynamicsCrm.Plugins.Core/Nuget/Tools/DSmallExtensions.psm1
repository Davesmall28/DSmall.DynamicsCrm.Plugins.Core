function DSmallPrivate-AddILMergePropertyToReferences($project) {
    if($project -eq $null) {
		$project = Get-Project
	}
	
	$references = $project.Object.References | Where-Object { $_.Name -notlike "System*" -and $_.Name -notlike "Microsoft*" -and $_.Name -ne "mscorlib" }
	$references | ForEach-Object { 
		$referenceName = "*" + $_.Name + "*"
		$buildProject = @([Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName))[0]
		$toEdit = $buildProject.Xml.Items | Where-Object { $_.Include -like $referenceName }
		$metadataItems = $toEdit.Metadata | Where-Object { $_.Name -eq "ILMerge" }
		if($metadataItems.Count -lt 1)
		{
			$toEdit.AddMetaData("AssemblyName", $_.Name + ".dll")
			$toEdit.AddMetaData("ILMerge", "true")
		}
	}
}

function DSmallPrivate-CopyAssemblyKeyToOutputDirectory($project) {
    if($project -eq $null) {
		Write-Host "Copy Assembly Key To Output Directory but $project is null"
		$project = Get-Project
	}
	#$project = Get-Project
	
	$assemblyKeyFileNameObject = $project.Properties.Item("AssemblyOriginatorKeyFile");
	if ($assemblyKeyFileNameObject -And $assemblyKeyFileNameObject.Value)
	{
		$assemblyKeyParentFolderName = Split-Path -Path $assemblyKeyFileNameObject.Value -Parent	
		if ($assemblyKeyParentFolderName)
		{
			$parentItem = $project.ProjectItems.Item($assemblyKeyParentFolderName)
			$assemblyKeyFileName = Split-Path -Path $assemblyKeyFileNameObject.Value -Leaf
			$item = $parentItem.ProjectItems.Item($assemblyKeyFileName)	
		}
		else
		{
			$assemblyKeyFileName = $assemblyKeyFileNameObject.Value
			$item = $project.ProjectItems.Item($assemblyKeyFileName)
		}
		
		if ($item)
		{
			$item.Properties.Item("CopyToOutputDirectory").Value = 1
		}
		
		return $assemblyKeyFileName;
	}
	
	throw [System.Exception] "Please sign your plug-in project with a strong name key file (https://msdn.microsoft.com/en-us/library/gg695782.aspx#sign)."
}

function DSmallPrivate-UninstallInputs($package) {
	$project = Get-Project
	
	Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
	$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
	
	$itemsToRemove = @()
	$itemsToRemove += $msbuild.Xml.Imports | Where-Object { $_.Project.EndsWith($package.Id + '.targets') }
	
	if ($itemsToRemove -and $itemsToRemove.length)
	{
		foreach ($itemToRemove in $itemsToRemove)
		{
			$msbuild.Xml.RemoveChild($itemToRemove) | out-null
		}
		
		$project.Save()
	}
}

function DSmallPrivate-UninstallTargets($project) {
	Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
	$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
	
	$targetsToRemove = @()
	$targetsToRemove += $msbuild.Xml.Targets | Where-Object { $_.Name.Equals('DSmallAfterBuild') }
	
	if ($targetsToRemove -and $targetsToRemove.length)
	{
		foreach ($targetToRemove in $targetsToRemove)
		{
			$msbuild.Xml.RemoveChild($targetToRemove) | out-null
		}
		
		$project.Save()
	}
}

function DSmallPrivate-RemoveMetadata($project) {
	$buildProject = @([Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName))[0]
	
	$ilMergeMetadata = $buildProject.Xml.Items.Metadata | Where-Object { $_.Name -eq "ILMerge" }
	$ilMergeMetadata | ForEach-Object { $_.Parent.RemoveChild($_) }
	
	$assemblyNameMetadata = $buildProject.Xml.Items.Metadata | Where-Object { $_.Name -eq "AssemblyName" }
	$assemblyNameMetadata | ForEach-Object { $_.Parent.RemoveChild($_) }
	
	$customItems = $buildProject.Xml.Items | Where-Object { $_.Name -eq "AssembliesToMerge" }
	$customItems | ForEach-Object { $_.Parent.RemoveChild($_) }
}

function Redo-DSmall() {
	$project = Get-Project
	
	DSmallPrivate-AddILMergePropertyToReferences($project)
	DSmallPrivate-CopyAssemblyKeyToOutputDirectory($project)
	
	$project.Save()
}

function Resolve-DSmall() {
	if($host.Name -ne "Package Manager Host")
	{
		Write-Host "Please only use Resolve-DSmall command from the Package Manager Console within Visual Studio."
		return
	}
	
	$project = Get-Project
	$dsmallPackage = Get-Package "DSmall.DynamicsCrm.Plugins.Core"
	
	# Uninstall
	Uninstall-DSmall($project, $dsmallPackage)
	
	# Install
	DSmallPrivate-CopyAssemblyKeyToOutputDirectory($project)
	DSmallPrivate-AddILMergePropertyToReferences($project)

	Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

	$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
	
	$dsmallPackageFile = $dsmallPackage.GetFiles() | Select-Object -First 1	
	$toolsPath = $dsmallPackageFile.SourcePath.Replace($dsmallPackageFile.Path, "tools")
	
	$projectUri = New-Object Uri($project.FullName, [System.UriKind]::Absolute)
	$targetsFile = [System.IO.Path]::Combine($toolsPath, $dsmallPackage.Id + '.targets')
	$targetUri = New-Object Uri($targetsFile, [System.UriKind]::Absolute)
	$relativePath = [System.Uri]::UnescapeDataString($projectUri.MakeRelativeUri($targetUri).ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)

	$ILMergeFileLocation = [System.IO.Path]::Combine($toolsPath, 'ILMerge.exe')
	$ILMergeFileLocationUri = new-object Uri($ILMergeFileLocation, [System.UriKind]::Absolute)
	$ILMergeFileLocationRelativePath = [System.Uri]::UnescapeDataString($projectUri.MakeRelativeUri($ILMergeFileLocationUri).ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)
 
	$import = $msbuild.Xml.AddImport($relativePath)
	$import.Condition = "Exists('$relativePath')"
	
	$targetFramework = """v4," + $env:ProgramFiles + "\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0"""

	$target = $msbuild.Xml.AddTarget("DSmallAfterBuild")
	$target.AfterTargets = "AfterBuild"

	$project.Save()

	$commandText = """$ILMergeFileLocationRelativePath"" /targetplatform:$targetFramework /keyfile:$assemblyKeyFileName `$(AdditionalParameters) /out:""`$(OutputFileName)"" ""`$(MainAssembly)"" @(AssembliesToMerge->'""`$(TargetDir)%(AssemblyName)""', ' ')"
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

	$project.Save()
}

function Uninstall-DSmall($package) {
	#$modules = Get-Module | Where-Object { $_.Name -eq 'DSmallExtensions' }
	#$modules | ForEach-Object {
	#	Remove-Module 'DSmallExtensions'
	#}
	
	$project = Get-Project
	
	DSmallPrivate-UninstallInputs($package)
	DSmallPrivate-UninstallTargets($project)
	DSmallPrivate-RemoveMetadata($project)
	
	$project.Save()
}

Export-ModuleMember DSmallPrivate-AddILMergePropertyToReferences
Export-ModuleMember DSmallPrivate-CopyAssemblyKeyToOutputDirectory
Export-ModuleMember DSmallPrivate-UninstallInputs
Export-ModuleMember DSmallPrivate-UninstallTargets
Export-ModuleMember DSmallPrivate-RemoveMetadata
Export-ModuleMember Redo-DSmall
Export-ModuleMember Resolve-DSmall
Export-ModuleMember Install-DSmall
Export-ModuleMember Uninstall-DSmall