#!/bin/bash

kiota generate                      \
  --language csharp                 \
  --openapi src/api/openapi.json    \
  --output src/client/generated     \
  --class-name VaultApiClient       \
  --namespace-name Vault.Client     \
  --clean-output
