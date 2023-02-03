#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


# ESTAGIO 1 
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# ESTAGIO 2
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Restaurant.API/WebAPI.csproj", "Restaurant.API/"]
COPY ["Restaurant.Domain/Domain.csproj", "Restaurant.Domain/"]
COPY ["Restaurant.Infrastructure/Infrastructure.Data.csproj", "Restaurant.Infrastructure/"]
RUN dotnet restore "Restaurant.API/WebAPI.csproj"
COPY . .
WORKDIR "/src/Restaurant.API"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

# ESTAGIO 3
FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish

# ESTAGIO 4
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]