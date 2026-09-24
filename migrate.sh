#!/bin/bash

if [ -z "$1" ]; then
    echo "must supply migration description"
    exit 1
fi

dotnet-ef                                              \
  migrations                                           \
  add "$1"                                             \
  --project src/infrastructure/infrastructure.csproj   \
  --startup-project src/api/api.csproj

dotnet-ef                                              \
  database update                                      \
  --project src/infrastructure/infrastructure.csproj   \
  --startup-project src/api/api.csproj
