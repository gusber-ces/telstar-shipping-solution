# CES - Route-planning accelerator

This accelerator is intended to be a great start for CES projects, while showcasing some of the functionality and best practices from [Netcompany .NET Foundation](https://goto.netcompany.com/cases/GTE1579/NCDOTNET).

The accelerator contains:
- Domain model with locations and connections.
- Pathing algorithm.
- Code-first database model in an in-memory database.
- Frontend to interact with the domain.
- Simple user-authentication.
- External API with token-authorization.

## Getting started

1. Run the `script/setup-artifactory-use.bat` script to authenticate access to the Netcompany Foundation NuGet repository. You will be prompted for your NCDMZ password.
2. Run the `script/update-nuget-trusted-authors.bat` script to set the trusted authors for NuGet.
   - Note that if you later need to add new NuGet packages, you will have to add the package authors to `script/trusted-nuget-authors.txt` and run the script again.
3. Open the `src/Netcompany.RoutePlanning.sln` solution in Visual Studio.
4. Start the `Netcompany.RoutePlanning.Web` project (**F5** is the default shortcut)
5. Once you have the solution running it will show further information to get you started. Good luck :)