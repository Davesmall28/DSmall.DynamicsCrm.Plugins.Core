@echo off
set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)

REM Update App.Config
echo ##myget[message text='Starting write to App.Config']
echo ^<?xml version="1.0" encoding="utf-8" ?^>^<configuration^>^<connectionStrings^>^<add name="CrmConnection" connectionString="Url=%CrmUrl%; Username=%Username%; Password=%Password%; DeviceID=%DeviceId%; DevicePassword=%DevicePassword%"/^>^</connectionStrings^>^</configuration^> > Springboard365.Xrm.Plugins.Core.IntegrationTest\Springboard365.Xrm.Plugins.Core.IntegrationTest\App.Config

REM NuGet Restore
echo ##myget[message text='Starting NuGet Restore' status='NORMAL']
call %nuget% restore Springboard365.Xrm.Plugins.Core.All.sln -NonInteractive

REM Build
echo ##myget[message text='Starting Build' status='NORMAL']
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild Springboard365.Xrm.Plugins.Core.All.sln /p:Configuration="%config%";OutDir=bin\%config% /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
if not "%errorlevel%"=="0" goto failure

REM Unit tests
echo ##myget[message text='Starting Unit tests' status='NORMAL']
"%GallioEcho%" Springboard365.Xrm.Plugins.Core.UnitTest\bin\%config%\Springboard365.Xrm.Plugins.Core.UnitTest.dll
if not "%errorlevel%"=="0" goto failure

REM Integration tests
echo ##myget[message text='Starting Integration tests' status='NORMAL']
"%GallioEcho%" Springboard365.Xrm.Plugins.Core.IntegrationTest\Springboard365.Xrm.Plugins.Core.IntegrationTest\bin\%config%\Springboard365.Xrm.Plugins.Core.IntegrationTest.dll
if not "%errorlevel%"=="0" goto failure

REM Package
mkdir Build
echo ##myget[message text='Starting NuGet Pack' status='NORMAL']
call %nuget% pack Springboard365.Xrm.Plugins.Core\Springboard365.Xrm.Plugins.Core.csproj -symbols -o Build -p Configuration=%config%;OutDir=bin\%config% %version%
if not "%errorlevel%"=="0" goto failure

:success
exit 0

:failure
exit -1