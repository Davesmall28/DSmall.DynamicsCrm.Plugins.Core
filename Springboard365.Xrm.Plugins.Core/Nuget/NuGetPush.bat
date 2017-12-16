SET packageVersion=1.0.0-beta4

NuGet.exe pack ../Springboard365.Xrm.Plugins.Core.csproj -Build -symbols -Version %packageVersion%

NuGet.exe push Springboard365.Xrm.Plugins.Core.%packageVersion%.nupkg

pause