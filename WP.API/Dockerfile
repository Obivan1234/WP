#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WP.API/WP.API.csproj", "WP.API/"]
COPY ["WP.BLL/WP.BLL.csproj", "WP.BLL/"]
COPY ["WP.DAL/WP.DAL.csproj", "WP.DAL/"]
COPY ["WP.Common/WP.Common.csproj", "WP.Common/"]
RUN dotnet restore "WP.API/WP.API.csproj"
COPY . .
WORKDIR "/src/WP.API"
RUN dotnet build "WP.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WP.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WP.API.dll"]