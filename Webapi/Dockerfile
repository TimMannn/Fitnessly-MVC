FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Webapi.csproj", "."]
RUN dotnet restore "Webapi.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Webapi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Webapi.dll"]
