# Gebruik een officiële .NET runtime image als een build omgeving
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Gebruik een officiële .NET SDK image als een build omgeving
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Web api/Web api.csproj", "Web api/"]
RUN dotnet restore "Web api/Web api.csproj"
COPY . .
WORKDIR "/src/Web api"
RUN dotnet build "Web api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web api.csproj" -c Release -o /app/publish

# Gebruik de base image en copy de publish output
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web api.dll"]
