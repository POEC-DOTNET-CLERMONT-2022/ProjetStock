FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./ ./
RUN dotnet restore ./ApiApplication.csproj

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out