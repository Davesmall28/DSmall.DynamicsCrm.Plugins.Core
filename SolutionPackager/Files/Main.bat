solutionpackager.exe /a:"Extract" /z:"..\%1.zip" /folder:"%1" /p:Both

rename %CrmSolutionName% SolutionExtract

rmdir /S /Q ..\..\Springboard365.Xrm.Plugins.Core.CrmSolution\SolutionExtract

move SolutionExtract ..\..\Springboard365.Xrm.Plugins.Core.CrmSolution

pause