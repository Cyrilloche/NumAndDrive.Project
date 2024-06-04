# Use the official ASP.NET image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["NumAndDrive/NumAndDrive.csproj", "NumAndDrive/"]
RUN dotnet restore "NumAndDrive/NumAndDrive.csproj"
COPY . .
WORKDIR "/src/NumAndDrive"
RUN dotnet build "NumAndDrive.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NumAndDrive.csproj" -c Release -o /app/publish

# Use the base image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NumAndDrive.dll"]
