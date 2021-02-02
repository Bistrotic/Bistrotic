#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Server/Bistrotic.Server.csproj", "src/Server/"]
COPY ["src/Shared/Bistrotic.Shared.csproj", "src/Shared/"]
COPY ["src/Client/Bistrotic.Client.csproj", "src/Client/"]
RUN dotnet restore "src/Server/Bistrotic.Server.csproj"
COPY . .
WORKDIR "/src/src/Server"
RUN dotnet build "Bistrotic.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bistrotic.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bistrotic.Server.dll"]