solutionpackager.exe /a:"Extract" /z:"..\%1.zip" /folder:"%1" /p:Both

rename %CrmSolutionName% SolutionExtract

rmdir /S /Q ..\..\CrmSolution\SolutionExtract

move SolutionExtract ..\..\CrmSolution

pause