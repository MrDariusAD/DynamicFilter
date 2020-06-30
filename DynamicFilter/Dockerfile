#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DynamicFilter/DynamicFilter.WebApi.csproj", "DynamicFilter/"]
COPY ["DynamicFilter.MongoDb/DynamicFilter.MongoDb.csproj", "DynamicFilter.MongoDb/"]
COPY ["DynamicFilter.Domain.Core/DynamicFilter.Domain.Core.csproj", "DynamicFilter.Domain.Core/"]
COPY ["DynamicFilter.Domain/DynamicFilter.Domain.csproj", "DynamicFilter.Domain/"]
RUN dotnet restore "DynamicFilter/DynamicFilter.WebApi.csproj"
COPY . .
WORKDIR "/src/DynamicFilter"
RUN dotnet build "DynamicFilter.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DynamicFilter.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DynamicFilter.WebApi.dll"]