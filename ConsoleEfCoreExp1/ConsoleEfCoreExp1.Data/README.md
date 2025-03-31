# EF Migration Tools
These are tools needed to run EF migrations.  Run the following command to see what you have installed
dotnet tool list --global

If you don't see a 6.x version, you should update your tools
Package Id      Version      Commands
--------------------------------------
dotnet-ef       9.0.3        dotnet-ef

Update your tools with this command:
dotnet tool update --global dotnet-ef --version 9.03

# EF Migrations
From the folder where the **solution file** is located run the following to create a migration:
```sql
 dotnet ef migrations add Initial -p ConsoleEfCoreExp1.Data -s ConsoleEfCoreExp1 --context AcmeDbContext
```

You can just run the project and EF migrations will update the database, but if you want to do it by hand run the following command
```sql
dotnet ef database update -p ConsoleEfCoreExp1.Data -s ConsoleEfCoreExp1 --context AcmeDbContext
```
 