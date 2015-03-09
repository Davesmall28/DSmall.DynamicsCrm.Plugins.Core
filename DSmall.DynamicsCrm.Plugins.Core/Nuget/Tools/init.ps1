param($installPath, $toolsPath, $package, $project)
	if($project -eq $null) {
		$project = Get-Project
	}

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

	$assemblyKeyFileName = $project.Properties.Item("AssemblyOriginatorKeyFile");
	if	($assemblyKeyFileName -And $assemblyKeyFileName.Value) {
		$item = $project.ProjectItems.Item($assemblyKeyFileName.Value)
		$item.Properties.Item("CopyToOutputDirectory").Value = 1
	}

	$project.Save()