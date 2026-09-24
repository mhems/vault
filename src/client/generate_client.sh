#!/bin/bash

kiota generate                      \
  --language csharp                 \
  --openapi ../api/openapi.json     \
  --output generated                \
  --class-name VaultApiClient       \
  --namespace-name Vault.Client
