# Utiliser l'image de base ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Utiliser l'image SDK pour construire l'application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["NumAndDrive/NumAndDrive.csproj", "NumAndDrive/"]
RUN dotnet restore "NumAndDrive/NumAndDrive.csproj"
COPY . .
WORKDIR "/src/NumAndDrive"
RUN dotnet build "NumAndDrive.csproj" -c Release -o /app/build

# Publier l'application
FROM build AS publish
RUN dotnet publish "NumAndDrive.csproj" -c Release -o /app/publish

# Construire l'image finale
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NumAndDrive.dll"]
