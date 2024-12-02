
ef core commands:

add new migrations: 
dotnet ef migrations add "Initial" -p .\Repository\Repository.csproj -s .\Web\Web.csproj

update database:
dotnet ef database update -p .\Repository\Repository.csproj -s .\Web\Web.csproj