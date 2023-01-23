# CES - Route-planning accelerator

This accelerator is intended to be a great start for CES projects, while showcasing some of the functionality and best practices from [Netcompany Foundation for .NET](https://goto.netcompany.com/cases/GTE1579/NCDOTNET).

The accelerator contains:
- Domain model with locations and connections.
- Pathing algorithm.
- Code-first database model in an in-memory database.
- Frontend to interact with the domain.
- Simple user-authentication.
- External API with token-authorization.

## Getting started

1. Run the `/script/setup-docker-login.bat` script to authenticate access to the Netcompany Foundation Docker repository. You will be prompted for your NCDMZ password.
2. Open the `src/RoutePlanning.sln` solution in Visual Studio.
3. Start the `RoutePlanning.Web` project (**F5** is the default shortcut)
4. Once you have the solution running it will show further information to get you started. Good luck :)
