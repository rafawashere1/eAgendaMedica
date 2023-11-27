#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eAgendaMedica.WebApi/eAgendaMedica.WebApi.csproj", "eAgendaMedica.WebApi/"]
COPY ["eAgendaMedica.Application/eAgendaMedica.Application.csproj", "eAgendaMedica.Application/"]
COPY ["eAgendaMedica.Domain/eAgendaMedica.Domain.csproj", "eAgendaMedica.Domain/"]
COPY ["eAgendaMedica.Infra.Orm/eAgendaMedica.Infra.Orm.csproj", "eAgendaMedica.Infra.Orm/"]
RUN dotnet restore "eAgendaMedica.WebApi/eAgendaMedica.WebApi.csproj"
COPY . .
WORKDIR "/src/eAgendaMedica.WebApi"
RUN dotnet build "eAgendaMedica.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eAgendaMedica.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eAgendaMedica.WebApi.dll"]