# syntax=docker/dockerfile:1
# Use the appropriate .NET SDK image as base
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

# Define working directory
WORKDIR /source/CMS.Web

# Copy the project file and restore dependencies
COPY . /source
COPY *.sln .
COPY CMS.CoreBusiness/CMS.CoreBusiness.csproj .
COPY CMS.UseCases/CMS.UseCases.csproj .
COPY CMS.Data/CMS.Data.csproj .
RUN dotnet restore /source/CMS.Web.sln

# This is the architecture you’re building for
ARG TARGETARCH

# Build the application
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -c release -a ${TARGETARCH/amd64/x64} /source/CMS.Web.sln --use-current-runtime --self-contained false -o /app

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app
COPY --from=build /app .
COPY migrate.sh /app/migrate.sh
RUN chmod +x /app/migrate.sh

ENTRYPOINT ["dotnet", "CMS.Web.dll"]
