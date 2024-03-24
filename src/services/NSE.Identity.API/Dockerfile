# Base
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
RUN apk add --no-cache libc6-compat
USER app
ENV APP_HOME /app
WORKDIR $APP_HOME
EXPOSE 8080
EXPOSE 8081

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ENV APP_HOME /app
ARG BUILD_CONFIGURATION=Release
WORKDIR $APP_HOME
COPY *.csproj $APP_HOME/
RUN dotnet restore "${APP_HOME}/NSE.Identity.API.csproj"
COPY . .
RUN dotnet build "${APP_HOME}/NSE.Identity.API.csproj" -c $BUILD_CONFIGURATION -o $APP_HOME/build

# Publish
FROM build AS publish
ENV APP_HOME /app
ARG BUILD_CONFIGURATION=Release
WORKDIR $APP_HOME
RUN dotnet publish "${APP_HOME}/NSE.Identity.API.csproj" -c $BUILD_CONFIGURATION -o $APP_HOME/publish /p:UseAppHost=false

# Final
FROM base AS final
ENV APP_HOME /app
COPY --from=publish $APP_HOME/publish .
ENTRYPOINT ["dotnet", "NSE.Identity.API.dll"]
