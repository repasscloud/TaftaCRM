# Migrations

1. Install necessary dotnet package
```sh
dotnet add package Microsoft.EntityFrameworkCore.Design
```

2. Install/update dotnet-ef tool
```sh
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
```

3. Create migration
```sh
dotnet ef migrations add _MigrationName_
```

4. Update database
```sh
dotnet ef database update
```

## Note About Using Docker

When using a Docker Compose configuration, the `appsettings.json` needs have the server changed from `db` to `localhost` or the `IP Address` from Docker. Then to start the specific container, use docker compose and specify:
```sh
docker compose up db -d
```