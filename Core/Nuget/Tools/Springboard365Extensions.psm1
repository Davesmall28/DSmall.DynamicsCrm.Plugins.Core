function Springboard365Private-AddILMergePropertyToReferences($project) {
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

function Springboard365Private-CopyAssemblyKeyToOutputDirectory($project) {
    if($project -eq $null) {
        Write-Host "Copy Assembly Key To Output Directory but $project is null"
        $project = Get-Project
    }
    
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

        return $assemblyKeyFileNameObject.Value
    }
    
    throw [System.Exception] "Please sign your plug-in project with a strong name key file (https://msdn.microsoft.com/en-us/library/gg695782.aspx#sign)."
}

function Springboard365Private-UninstallImports($package) {
    $project = Get-Project
    $packageId = 'Springboard365.Xrm.Plugins.Core'

    Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
    $msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

    $itemsToRemove = @()
    $itemsToRemove += $msbuild.Xml.Imports | Where-Object { $_.Project.EndsWith($packageId + '.targets') }
    
    if ($itemsToRemove -and $itemsToRemove.length)
    {
        foreach ($itemToRemove in $itemsToRemove)
        {
            $msbuild.Xml.RemoveChild($itemToRemove) | out-null
        }
        
        $project.Save()
    }
}

function Springboard365Private-UninstallTargets($project) {
    Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
    $msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
    
    $targetsToRemove = @()
    $targetsToRemove += $msbuild.Xml.Targets | Where-Object { $_.Name.Equals('Springboard365AfterBuild') }
    
    if ($targetsToRemove -and $targetsToRemove.length)
    {
        foreach ($targetToRemove in $targetsToRemove)
        {
            $msbuild.Xml.RemoveChild($targetToRemove) | out-null
        }
        
        $project.Save()
    }
}

function Springboard365Private-RemoveMetadata($project) {
    $buildProject = @([Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName))[0]
    
    $ilMergeMetadata = $buildProject.Xml.Items.Metadata | Where-Object { $_.Name -eq "ILMerge" }
    $ilMergeMetadata | ForEach-Object { $_.Parent.RemoveChild($_) }
    
    $assemblyNameMetadata = $buildProject.Xml.Items.Metadata | Where-Object { $_.Name -eq "AssemblyName" }
    $assemblyNameMetadata | ForEach-Object { $_.Parent.RemoveChild($_) }
    
    $customItems = $buildProject.Xml.Items | Where-Object { $_.Name -eq "AssembliesToMerge" }
    $customItems | ForEach-Object { $_.Parent.RemoveChild($_) }
}

function Redo-Springboard365() {
    $project = Get-Project
    
    Springboard365Private-AddILMergePropertyToReferences($project)
    Springboard365Private-CopyAssemblyKeyToOutputDirectory($project)
    
    $project.Save()
}

function Resolve-Springboard365() {
    if($host.Name -ne "Package Manager Host")
    {
        Write-Host "Please only use Resolve-Springboard365 command from the Package Manager Console within Visual Studio."
        return
    }
    
    $project = Get-Project
    $package = Get-Package "Springboard365.Xrm.Plugins.Core"
    
    # Uninstall
    Uninstall-Springboard365($project, $package)
    
    # Install
    $assemblyKeyFileName = Springboard365Private-CopyAssemblyKeyToOutputDirectory($project)
    Springboard365Private-AddILMergePropertyToReferences($project)

    Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

    $msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
    
    $packageFile = $package.GetFiles() | Select-Object -First 1	
    $toolsPath = $packageFile.SourcePath.Replace($packageFile.Path, "tools")
    
    $projectUri = New-Object Uri($project.FullName, [System.UriKind]::Absolute)
    $targetsFile = [System.IO.Path]::Combine($toolsPath, $package.Id + '.targets')
    $targetUri = New-Object Uri($targetsFile, [System.UriKind]::Absolute)
    $relativePath = [System.Uri]::UnescapeDataString($projectUri.MakeRelativeUri($targetUri).ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)

    $ILMergeFileLocation = [System.IO.Path]::Combine($toolsPath, 'ILMerge.exe')
    $ILMergeFileLocationUri = New-Object Uri($ILMergeFileLocation, [System.UriKind]::Absolute)
    $ILMergeFileLocationRelativePath = [System.Uri]::UnescapeDataString($projectUri.MakeRelativeUri($ILMergeFileLocationUri).ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)
 
    $import = $msbuild.Xml.AddImport($relativePath)
    $import.Condition = "Exists('$relativePath')"
    
    $targetFramework = """v4," + $env:ProgramFiles + "\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.2"""

    $target = $msbuild.Xml.AddTarget("Springboard365AfterBuild")
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

    $node = $xml.Project.SelectSingleNode("//msbld:Target[@Name='Springboard365AfterBuild']", $nsmgr)
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

function Uninstall-Springboard365($package) {
    #$modules = Get-Module | Where-Object { $_.Name -eq 'Springboard365Extensions' }
    #$modules | ForEach-Object {
    #	Remove-Module 'Springboard365Extensions'
    #}
    
    $project = Get-Project
    
    Springboard365Private-UninstallImports($package)
    Springboard365Private-UninstallTargets($project)
    Springboard365Private-RemoveMetadata($project)
    
    $project.Save()
}

Export-ModuleMember Springboard365Private-AddILMergePropertyToReferences
Export-ModuleMember Springboard365Private-CopyAssemblyKeyToOutputDirectory
Export-ModuleMember Springboard365Private-UninstallImports
Export-ModuleMember Springboard365Private-UninstallTargets
Export-ModuleMember Springboard365Private-RemoveMetadata
Export-ModuleMember Redo-Springboard365
Export-ModuleMember Resolve-Springboard365
Export-ModuleMember Install-Springboard365
Export-ModuleMember Uninstall-Springboard365