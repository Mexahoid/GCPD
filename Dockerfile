# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /GCPD

# copy csproj and restore as distinct layers
COPY /GCPD/*.csproj .
COPY /Interfaces/*.csproj .
COPY /ModelsLibrary/*.csproj .
COPY /TestService/*.csproj .
RUN dotnet restore GCPD.csproj

# copy and publish app and libraries
COPY . .
RUN dotnet publish -c release -o /app --no-restore GCPD.csproj

# final stage/image
FROM mcr.microsoft.com/dotnet/core/runtime:2.1
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "GCPD.dll"]