#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APIGatewayLayer/APIGatewayLayer.csproj", "APIGatewayLayer/"]
RUN dotnet restore "APIGatewayLayer/APIGatewayLayer.csproj"
COPY . .
WORKDIR "/src/APIGatewayLayer"
RUN dotnet build "APIGatewayLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIGatewayLayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIGatewayLayer.dll"]
