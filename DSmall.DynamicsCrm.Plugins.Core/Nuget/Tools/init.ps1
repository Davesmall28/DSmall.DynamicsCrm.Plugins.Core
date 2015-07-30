param($installPath, $toolsPath, $package, $project)
    $modules = Get-Module | Where-Object { $_.Name -eq 'DSmallExtensions' }
    $modules | ForEach-Object {
        Remove-Module 'DSmallExtensions'
    }

    Import-Module (Join-Path $toolsPath DSmallExtensions.psm1)

    if($project -eq $null) {
        $project = Get-Project
    }
    
    DSmallPrivate-CopyAssemblyKeyToOutputDirectory($project)
    DSmallPrivate-AddILMergePropertyToReferences($project)
    
    $project.Save()