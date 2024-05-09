1. Install/update the dotnet code generator
```sh
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool update --global dotnet-aspnet-codegenerator
```

2. Install required packages
```sh
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

3. Scaffold a Controller
```sh
dotnet aspnet-codegenerator controller -name YourControllerName -m YourModel -dc YourDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```

4. Scaffold an API Controller
```sh
dotnet aspnet-codegenerator controller --controllerName UserAccountController --model TaftaCRM.Models.Internal.System.UserAccount --dataContext TaftaCRM.Data.AppDbContext --relativeFolderPath Controllers --restWithNoViews --useAsyncActions
```

5. Build and Run
```sh
dotnet build
dotnet run
```


## Using Namespaces

When creating using this tool, use the full namespace:
```sh
dotnet aspnet-codegenerator controller -name UserAccountController -m TaftaCRM.Models.Internal.System.UserAccount -dc TaftaCRM.Data.AppDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```