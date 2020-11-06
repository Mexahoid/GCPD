# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY /GCPD/* ./GCPD/
COPY /Interfaces/* ./Interfaces/
COPY /ModelsLibrary/* ./ModelsLibrary/
COPY /TestService/* ./TestService/
COPY *.sln .
# WORKDIR /source/GCPD

RUN dotnet restore GCPD.sln

# copy and publish app and libraries
# COPY . ../.
# WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore GCPD.sln

# final stage/image
FROM mcr.microsoft.com/dotnet/core/runtime:2.1
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "GCPD.dll"]