FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend.csproj", "/"]

COPY . .
WORKDIR "/src/"
RUN dotnet build "BallApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BallApp.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend.dll"]
