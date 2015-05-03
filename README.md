# DSmall.DynamicsCrm.Plugins.Core

[![Build Status](https://magnum.travis-ci.com/Davesmall28/DSmall.DynamicsCrm.Plugins.Core.svg?token=syrh3amDgq9dtpK7qH4B&branch=master)](https://magnum.travis-ci.com/Davesmall28/DSmall.DynamicsCrm.Plugins.Core)&nbsp;&nbsp;&nbsp;[![dsmallltd MyGet Build Status](https://www.myget.org/BuildSource/Badge/dsmallltd?identifier=8f3169ea-c2fa-4f43-971d-8e899ec1af67)](https://www.myget.org/)

##What is it?
When creating Plugins for Microsoft Dynamics Crm there is alot of boiler plate code needed to extract the IOrganizationService, the ITracingService and the IPluginExecutionContext from the IServiceProvider. This is boiler plate code that we usually just copy and paste and which can distract from the business logic we implement within the plugin.

I created the DSmall.DynamicsCrm.Plugins.Core NuGet package to remove alot of the boiler plate code and to make mocking the plugin code easier.

##How does it do it?
Normally in plugins we create a class file and implement the interface "IPlugin" which has an Execute method with one paramater of type IServiceProvider. This allows Crm plugins to be generic as the IServiceProvider allows a way of getting any object by specifying only the type. After installing DSmall.DynamicsCrm.Plugins.Core instead of implementing an interface we derive from the abstract class Plugin which now has a Execute method with parameters IOrganizationService, IPluginExecutionContext and ITracingService which can be overridden and on execution of the plugin the DSmall.DynamicsCrm.Plugins.Core framework takes care of delivering these parameters to your plugin class file.

##Installing Package from NuGet
First, install NuGet. Then, install DSmall.DynamicsCrm.Plugins.Core from the package manager console: 
![Install-Package DSmall.DynamicsCrm.Plugins.Core](https://raw.githubusercontent.com/Davesmall28/DSmallWikiImages/master/InstallPackage_DSmall-Plugin-Core.png)
