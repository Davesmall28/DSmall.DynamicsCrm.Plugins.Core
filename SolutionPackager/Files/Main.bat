solutionpackager.exe /a:"Extract" /z:"..\%1.zip" /folder:"%1" /p:Both

rename %CrmSolutionName% DSmallPluginCore

xcopy /Y DSmallPluginCore ..\..\DSmall.DynamicsCrm.Plugins.Core.CrmSolution

pause