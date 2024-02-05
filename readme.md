```
dotnet new console -n AutoUpdate  
```
```
dotnet add package System.Net.Http.Json
dotnet add package Newtonsoft.Json
```

```
dotnet publish -c Release -r win11-x64

dotnet run

dotnet build 
```

