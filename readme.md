dotnet new console -n AutoUpdate  

dotnet publish -c Release -r win11-x64
dotnet add package System.Net.Http.Json
dotnet add package Newtonsoft.Json

dotnet run
dotnet build