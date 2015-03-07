param($installPath, $toolsPath, $package, $project)

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

  $buildProject = @([Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName))[0]

  $ilMergeMetadata = $buildProject.Xml.Items.Metadata | Where-Object { $_.Name -eq "ILMerge" }
  $ilMergeMetadata | ForEach-Object { $_.Parent.RemoveChild($_) }

  $assemblyNameMetadata = $buildProject.Xml.Items.Metadata | Where-Object { $_.Name -eq "AssemblyName" }
  $assemblyNameMetadata | ForEach-Object { $_.Parent.RemoveChild($_) }

  $customItems = $buildProject.Xml.Items | Where-Object { $_.Name -eq "AssembliesToMerge" }
  $customItems | ForEach-Object { $_.Parent.RemoveChild($_) }

  $project.Save()