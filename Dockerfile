# Begin met de basis .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Stel de werkdirectory in voor de build stappen
WORKDIR /src

# Kopieer de .csproj bestanden en herstel de afhankelijkheden
COPY ["Webapi/Webapi.csproj", "Webapi/"]
COPY ["BLL/BLL.csproj", "BLL/"]
COPY ["DAL.EntityFramework/DAL.EntityFramework.csproj", "DAL.EntityFramework/"]
RUN dotnet restore "Webapi/Webapi.csproj"

# Kopieer de volledige inhoud van de mappen
COPY . .

# Stel de werkdirectory in voor de build
WORKDIR /src/Webapi
RUN dotnet build "Webapi.csproj" -c Release -o /app/build

# Publiceer de applicatie
FROM build AS publish
RUN dotnet publish "Webapi.csproj" -c Release -o /app/publish

# Gebruik de ASP.NET runtime image voor de uiteindelijke container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 7187
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Webapi.dll"]