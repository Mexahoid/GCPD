# https://hub.docker.com/_/microsoft-dotnet-coreasds
# FROM gcr.io/google-appengine/aspnetcore:2.1.1
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY /GCPD/* ./GCPD/
COPY /Interfaces/* ./Interfaces/
COPY /ModelsLibrary/* ./ModelsLibrary/
COPY /TestService/* ./TestService/
# COPY /FrontEnd/* ./FrontEnd/
COPY *.sln .
# WORKDIR /source/GCPD

RUN dotnet restore GCPD.sln

# copy and publish app and libraries
# COPY . ../.
# WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore GCPD.sln

# final stage/image s
FROM gcr.io/google-appengine/aspnetcore:2.1.1
# FROM mcr.microsoft.com/dotnet/core/runtime:2.1
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "GCPD.dll"]