FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sample.GrapQLDapperApi/Sample.GrapQLDapperApi.csproj", "Sample.GrapQLDapperApi/"]
RUN dotnet restore "Sample.GrapQLDapperApi/Sample.GrapQLDapperApi.csproj"
COPY . .
WORKDIR "/src/Sample.GrapQLDapperApi"
RUN dotnet build "Sample.GrapQLDapperApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sample.GrapQLDapperApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.GrapQLDapperApi.dll"]
