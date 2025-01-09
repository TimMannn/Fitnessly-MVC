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
EXPOSE 443

# Voeg de certificaten toe (indien aanwezig in de map ./certificates)
COPY ./certificates /etc/ssl/certs/

# Kopieer de gepubliceerde bestanden
COPY --from=publish /app/publish .

# Installeer MySQL-client
RUN apt-get update && apt-get install -y gnupg
RUN apt-key adv --recv-keys --keyserver keyserver.ubuntu.com 5072E1F5
RUN apt-get update && apt-get install -y mysql-client

# Stel de applicatie in om te luisteren op HTTPS
ENV ASPNETCORE_URLS=https://+:443

# Stel het pad naar het certificaat en de sleutel in (vervang met je echte pad)
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/etc/ssl/certs/cert.pem
ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/etc/ssl/certs/key.pem

ENTRYPOINT ["dotnet", "Webapi.dll"]
