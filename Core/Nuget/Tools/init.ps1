param($installPath, $toolsPath, $package, $project)
    $modules = Get-Module | Where-Object { $_.Name -eq 'Springboard365Extensions' }
    $modules | ForEach-Object {
        Remove-Module 'Springboard365Extensions'
    }

    Import-Module (Join-Path $toolsPath Springboard365Extensions.psm1)

    if($project -eq $null) {
        $project = Get-Project
    }
    
    Springboard365Private-CopyAssemblyKeyToOutputDirectory($project)
    Springboard365Private-AddILMergePropertyToReferences($project)
    
    $project.Save()