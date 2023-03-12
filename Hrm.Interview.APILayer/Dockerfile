#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV InterviewApi="Data Source=192.168.1.193,1433;Initial Catalog=InterviewDb;User ID=sa;Password=Admin@1234;TrustServerCertificate=True"
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hrm.Interview.APILayer/Hrm.Interview.APILayer.csproj", "Hrm.Interview.APILayer/"]
COPY ["Hrm.Interview.Infrastructure/Hrm.Interview.Infrastructure.csproj", "Hrm.Interview.Infrastructure/"]
COPY ["Hrm.Interview.ApplicationCore/Hrm.Interview.ApplicationCore.csproj", "Hrm.Interview.ApplicationCore/"]
RUN dotnet restore "Hrm.Interview.APILayer/Hrm.Interview.APILayer.csproj"
COPY . .
WORKDIR "/src/Hrm.Interview.APILayer"
RUN dotnet build "Hrm.Interview.APILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hrm.Interview.APILayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hrm.Interview.APILayer.dll"]
