#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV AuthenticationApi="Data Source=192.168.1.200,1433;Initial Catalog=AuthenticationDb;User ID=sa;Password=Admin@1234;TrustServerCertificate=True"
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hrm.Authentication.APILayer/Hrm.Authentication.APILayer.csproj", "Hrm.Authentication.APILayer/"]
COPY ["Hrm.Authentication.Infrastructure/Hrm.Authentication.Infrastructure.csproj", "Hrm.Authentication.Infrastructure/"]
COPY ["Hrm.Authentication.ApplicationCore/Hrm.Authentication.ApplicationCore.csproj", "Hrm.Authentication.ApplicationCore/"]
RUN dotnet restore "Hrm.Authentication.APILayer/Hrm.Authentication.APILayer.csproj"
COPY . .
WORKDIR "/src/Hrm.Authentication.APILayer"
RUN dotnet build "Hrm.Authentication.APILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hrm.Authentication.APILayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hrm.Authentication.APILayer.dll"]
