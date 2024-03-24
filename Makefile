﻿.PHONY: up
up:
	docker-compose up -d

.PHONY: up_build
up_build:
	docker-compose up -d --build

.PHONY: down
down:
	docker-compose down

.PHONY: logs_identity
logs_identity:
	docker logs -f nerdstoreenterprise-nerdstore_identity-1

.PHONY: restore_csproj
restore_csproj:
	dotnet restore ./src/services/NSE.Identity.API/NSE.Identity.API.csproj

.PHONY: createmigration
create_migration_identity:
	dotnet ef migrations add NerdStore -s ./src/services/NSE.Identity.API -p ./src/services/NSE.Identity.API

.PHONY: migrate
migrate_identity:
	 dotnet ef database update -s ./src/services/NSE.Identity.API -p ./src/services/NSE.Identity.API