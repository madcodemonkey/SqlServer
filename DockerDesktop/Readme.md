# Summary
This folder contains a docker compose file to create a local instance of SQL Server (Linux versino) that I can attach to.

# Requirements
Docker Desktop is installed.

# Usage
At a command prompt inside this directory, use one of these two ways

## Way 1: It takes control of the prompt till your done
Start command: 
```docker compose up```

Stop command:
Use CTRL-C, which will stop it.

## Way 2: It frees the prompt immediately and runs as a deamon 
Start command: 
```docker compose up -d```

Stop command:
```docker compose down```

# Connection strings
If you use the defaults, the connection string for should be
```
Server=localhost;Initial Catalog=WorkActivities;USER ID=SA;Password=SQLpwd874237
```



Reference
- https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.connectionstring
- https://www.connectionstrings.com/sql-server/