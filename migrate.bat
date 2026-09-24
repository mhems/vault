@echo off

if [%1]==[] (
    echo "must supply migration description"
    exit /b 1
)

dotnet-ef                                              ^
  migrations                                           ^
  add %1                                               ^
  --project src\infrastructure\infrastructure.csproj   ^
  --startup-project src\api\api.csproj

dotnet-ef                                              ^
  database update                                      ^
  --project src\infrastructure\infrastructure.csproj   ^
  --startup-project src\api\api.csproj
