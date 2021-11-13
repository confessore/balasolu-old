FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS dotnet-build-base
WORKDIR /src
RUN apt-get update && apt-get install curl -y \
  && curl -sL https://deb.nodesource.com/setup_14.x | bash -\
  && apt-get install nodejs -y
COPY balasolu.sln .
COPY src/**/*.csproj .
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
RUN dotnet restore balasolu.sln
COPY . . 

FROM dotnet-build-base AS dotnet-build
RUN dotnet build -c Debug --no-restore balasolu.sln

FROM dotnet-build AS dotnet-test
RUN dotnet test -c Debug --no-build --no-restore balasolu.sln

FROM dotnet-build AS publish
RUN dotnet publish -c Debug --no-build --no-restore -o /app  src/balasolu.web/balasolu.web.csproj

FROM base AS final
COPY --from=publish /app .
COPY --from=publish /src/scripts/healthcheck.sh .
ENTRYPOINT ["dotnet", "balasolu.web.dll"]
