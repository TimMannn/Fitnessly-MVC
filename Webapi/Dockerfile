# Begin met een officieel .NET Core SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopieer de .csproj bestanden en herstel de afhankelijkheden
COPY ["Webapi/Webapi.csproj", "Webapi/"]
RUN dotnet restore "Webapi/Webapi.csproj"

# Kopieer de rest van de bestanden en bouw de applicatie
COPY . .
WORKDIR "/src/Webapi"
RUN dotnet build "Webapi.csproj" -c Release -o /app/build

# Publiceer de applicatie
FROM build AS publish
RUN dotnet publish "Webapi.csproj" -c Release -o /app/publish

# Maak een nieuwe image voor de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Webapi.dll"]
