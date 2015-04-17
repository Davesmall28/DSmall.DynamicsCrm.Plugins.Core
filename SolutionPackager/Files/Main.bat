solutionpackager.exe /a:"Extract" /z:"..\%1.zip" /folder:"%1" /p:Both

rename %CrmSolutionName% DSmallPluginCore

rmdir /S /Q ..\..\DSmall.DynamicsCrm.Plugins.Core.CrmSolution\DSmallPluginCore

move DSmallPluginCore ..\..\DSmall.DynamicsCrm.Plugins.Core.CrmSolution

pause