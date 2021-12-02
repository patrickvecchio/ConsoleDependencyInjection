# ConsoleDependencyInjection
This project demonstrates using Dependency Injection and appsettings files familiar to ASP.Net developers in a console app.

## Overview
Gone are the days of new'ing up a class and having to supply a bunch of dependencies.  All of the Dependency Injection is encapsulated in a Startup class.  I've included samples of appsettings and show overriding them with an environment-specific file using the ASPNETCORE_ENVIRONMENT environment variable.

I've also included a test project demonstrating how you could use the methods in the Startup class to inject mock versions of your classes.  The test project also shows how to use an in-memory collection to override appsettings files in your test project.

## Troubleshooting
If you're copying code from here and something doesn't work, it's likely because you didn't include the right NuGet packages.  Where ASP.Net automatically adds all the right dependencies, in a console app you'll have to add them manually.  So, take a look at the NuGet packages in the .csproj files and make sure you didn't miss one.

Another issue I've run into is using different versions of the NuGet packages.  It's fairly unscientific and I wish I had written down the exact circumstances, but I have been using the version of the packages that match the version of .Net that I'm using (e.g. .Net 3.1 project, version 3.1.19 of Microsoft.Extensions.Configuration as opposed to 5.0.0).
