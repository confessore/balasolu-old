FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS dotnet-build-base
WORKDIR /src
RUN --mount=type=cache,target=/var/cache/apt apt update && apt install curl -y \
  && curl -sL https://deb.nodesource.com/setup_14.x | bash -\
  && apt install nodejs -y && rm -rf /var/lib/apt/lists/*
COPY balasolu.sln .
COPY ./src/balasolu ./src/balasolu
RUN dotnet restore balasolu.sln

FROM dotnet-build-base AS dotnet-build
RUN dotnet build -c Release --no-restore balasolu.sln

FROM dotnet-build AS dotnet-test
RUN dotnet test -c Release --no-build --no-restore balasolu.sln

FROM dotnet-build AS publish
RUN dotnet publish -c Release --no-build --no-restore -o /app src/balasolu/balasolu.csproj

FROM base AS final
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "balasolu.dll"]
 