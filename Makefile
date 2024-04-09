﻿.PHONY: up
up:
	docker-compose up -d

.PHONY: up_build
up_build:
	docker-compose up -d --build

.PHONY: down
down:
	docker-compose down

.PHONY: project_reference
project_reference:
	dotnet add $(1) reference $(2)

.PHONY: identity_restore_csproj
identity_restore_csproj:
	dotnet restore ./src/services/NSE.Identity.API/NSE.Identity.API.csproj

.PHONY: identity_create_migration
identity_create_migration:
	dotnet ef migrations add NerdStore -s ./src/services/NSE.Identity.API -p ./src/services/NSE.Identity.API

.PHONY: identity_migrate
identity_migrate:
	dotnet ef database update -s ./src/services/NSE.Identity.API -p ./src/services/NSE.Identity.API

.PHONY: identity_logs
identity_logs:
	docker logs -f nerdstoreenterprise-nerdstore_identity-1

.PHONY: catalog_create_migration
catalog_create_migration:
	dotnet ef migrations add NerdStore -s ./src/services/NSE.Catalog.API -p ./src/services/NSE.Catalog.API

.PHONY: catalog_migrate
catalog_migrate:
	dotnet ef database update -s ./src/services/NSE.Catalog.API -p ./src/services/NSE.Catalog.API

.PHONY: catalog_logs
catalog_logs:
	docker logs -f nerdstoreenterprise-nerdstore_catalog-1
