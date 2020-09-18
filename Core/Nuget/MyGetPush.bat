SET packageVersion=2.0.0-alpha01

NuGet.exe pack ../Springboard365.Xrm.Plugins.Core.csproj -Build -symbols -Version %packageVersion%

NuGet.exe push Springboard365.Xrm.Plugins.Core.%packageVersion%.nupkg -Source https://www.myget.org/F/springboard365-xrm-plugins/auth/af288cc7-7c0b-4076-9937-5cfaf6d980b5/api/v3/index.json

pause