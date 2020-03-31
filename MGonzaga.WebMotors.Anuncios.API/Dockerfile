FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MGonzaga.WebMotors.Anuncios.API/MGonzaga.WebMotors.Anuncios.API.csproj", "MGonzaga.WebMotors.Anuncios.API/"]
RUN dotnet restore "MGonzaga.WebMotors.Anuncios.API/MGonzaga.WebMotors.Anuncios.API.csproj"
COPY . .
WORKDIR "/src/MGonzaga.WebMotors.Anuncios.API"
RUN dotnet build "MGonzaga.WebMotors.Anuncios.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MGonzaga.WebMotors.Anuncios.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MGonzaga.WebMotors.Anuncios.API.dll"]