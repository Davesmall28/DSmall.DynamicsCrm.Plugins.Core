SET packageVersion=2.0.0-alpha01

NuGet.exe pack ../Springboard365.Xrm.Plugins.Core.csproj -Build -symbols -Version %packageVersion%

NuGet.exe push Springboard365.Xrm.Plugins.Core.%packageVersion%.nupkg

pause