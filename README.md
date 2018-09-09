# ASPNetCoreApiExample
Small example showing the base functionality of the restful api by example
The example contains an ASP.NET Core API Service, which runs inside a linux docker container
The example also contains a Client-Library, which contains a Client which allows you to communicate with the API Service

## Prequesits
* .NET Standard 2.0
  * https://blogs.msdn.microsoft.com/benjaminperkins/2017/09/20/how-to-install-net-standard-2-0/
* Installed Docker 
  * https://www.docker.com/get-started 
* ASP.NET.Core
  * Start the Visual Studio Installer (press WindowsButton, search for Installer, select it) 
  * Chose the installed edition and press change, add the ASP.NET Workload
* Have atleast .NET 4.6.1 installed

## Client
Use the ClientClass in your ClientApplication to communicate with the API

## Controller
The Controller adds a route for example: ImagesController adds the Images route which results in /api/images


