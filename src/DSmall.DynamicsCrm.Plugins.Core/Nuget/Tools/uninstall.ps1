param($installPath, $toolsPath, $package, $project)
  # Need to load MSBuild assembly if it's not loaded yet.
  Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

  # Grab the loaded MSBuild project for the project
  $msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

  # Find all the imports and targets added by this package.
  $itemsToRemove = @()

  # Allow many in case a past package was incorrectly uninstalled
  $itemsToRemove += $msbuild.Xml.Imports | Where-Object { $_.Project.EndsWith($package.Id + '.targets') }
  
  # Remove the elements and save the project
  if ($itemsToRemove -and $itemsToRemove.length)
  {
	 foreach ($itemToRemove in $itemsToRemove)
	 {
		 $msbuild.Xml.RemoveChild($itemToRemove) | out-null
	 }
	 
	 $project.Save()
  }

  $targetsToRemove = @()
  $targetsToRemove += $msbuild.Xml.Targets | Where-Object { $_.Name.Equals('DSmallAfterBuild') }
  Write-Host($targetsToRemove)
  
  # Remove the elements and save the project
  if ($targetsToRemove -and $targetsToRemove.length)
  {
	 foreach ($targetToRemove in $targetsToRemove)
	 {
		 $msbuild.Xml.RemoveChild($targetToRemove) | out-null
	 }
	 
	 $project.Save()
  }

  $buildProject = @([Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName))[0]
  $metadataItems = $buildProject.Xml.Items.Metadata | Where-Object { $_.Name -eq "ILMerge" }
  $metadataItems | ForEach-Object { $_.Parent.RemoveChild($_) }

  $customItems = $buildProject.Xml.Items | Where-Object { $_.Name -eq "AssembliesToMerge" }
  $customItems | ForEach-Object { $_.Parent.RemoveChild($_) }

  $project.Save()