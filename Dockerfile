FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY Colors.sln ./
COPY Colors.WebApi/*.csproj ./Colors.WebApi/
COPY Colors.Tests/*.csproj ./Colors.Tests/

RUN dotnet restore
COPY . .

WORKDIR /src/Colors.WebApi
RUN dotnet build -c Release -o /app

WORKDIR /src/Colors.Tests
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app . 

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Colors.WebApi.dll