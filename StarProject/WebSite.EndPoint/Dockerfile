#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Presentation/Shop_WebSite_EndPoint/Shop_WebSite_EndPoint.csproj", "Src/Presentation/Shop_WebSite_EndPoint/"]
RUN dotnet restore "./Src/Presentation/Shop_WebSite_EndPoint/./Shop_WebSite_EndPoint.csproj"
COPY . .
WORKDIR "/src/Src/Presentation/Shop_WebSite_EndPoint"
RUN dotnet build "./Shop_WebSite_EndPoint.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Shop_WebSite_EndPoint.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shop_WebSite_EndPoint.dll"]