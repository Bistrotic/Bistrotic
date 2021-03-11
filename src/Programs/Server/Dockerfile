#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/Programs/Server/Bistrotic.Server.csproj", "src/Programs/Server/"]
COPY ["src/Modules/Server/Bistrotic.QuartzScheduler.Server/Bistrotic.QuartzScheduler.Server.csproj", "src/Modules/Server/Bistrotic.QuartzScheduler.Server/"]
COPY ["src/Modules/Shared/Bistrotic.QuartzScheduler.Shared/Bistrotic.QuartzScheduler.Shared.csproj", "src/Modules/Shared/Bistrotic.QuartzScheduler.Shared/"]
COPY ["src/Core/Domain/Bistrotic.Domain.Abstractions/Bistrotic.Domain.Abstractions.csproj", "src/Core/Domain/Bistrotic.Domain.Abstractions/"]
COPY ["src/Core/Application/Bistrotic.Application.Abstractions/Bistrotic.Application.Abstractions.csproj", "src/Core/Application/Bistrotic.Application.Abstractions/"]
COPY ["src/Core/Infrastructure/Bistrotic.Infrastructure.WebServer/Bistrotic.Infrastructure.WebServer.csproj", "src/Core/Infrastructure/Bistrotic.Infrastructure.WebServer/"]
COPY ["src/Core/Infrastructure/Bistrotic.Infrastructure.Abstractions/Bistrotic.Infrastructure.Abstractions.csproj", "src/Core/Infrastructure/Bistrotic.Infrastructure.Abstractions/"]
COPY ["src/Core/Infrastructure/Bistrotic.Infrastructure.Host/Bistrotic.Infrastructure.Host.csproj", "src/Core/Infrastructure/Bistrotic.Infrastructure.Host/"]
COPY ["src/Core/Application/Bistrotic.Application/Bistrotic.Application.csproj", "src/Core/Application/Bistrotic.Application/"]
COPY ["src/Core/Infrastructure/Bistrotic.Infrastructure.Modules/Bistrotic.Infrastructure.Modules.csproj", "src/Core/Infrastructure/Bistrotic.Infrastructure.Modules/"]
COPY ["src/Modules/Server/Bistrotic.WorkItems.Server/Bistrotic.WorkItems.Server.csproj", "src/Modules/Server/Bistrotic.WorkItems.Server/"]
COPY ["src/Modules/Shared/Bistrotic.WorkItems.Shared/Bistrotic.WorkItems.Shared.csproj", "src/Modules/Shared/Bistrotic.WorkItems.Shared/"]
COPY ["src/Programs/Client/Bistrotic.Client.csproj", "src/Programs/Client/"]
COPY ["src/Modules/Client/Bistrotic.Units.Client/Bistrotic.Units.Client.csproj", "src/Modules/Client/Bistrotic.Units.Client/"]
COPY ["src/Modules/Client/Bistrotic.WorkItems.Client/Bistrotic.WorkItems.Client.csproj", "src/Modules/Client/Bistrotic.WorkItems.Client/"]
COPY ["src/Core/Infrastructure/Bistrotic.Infrastructure.BlazorClient/Bistrotic.Infrastructure.BlazorClient.csproj", "src/Core/Infrastructure/Bistrotic.Infrastructure.BlazorClient/"]
COPY ["src/Modules/Client/Bistrotic.OpenIdDict.Client/Bistrotic.OpenIdDict.Client.csproj", "src/Modules/Client/Bistrotic.OpenIdDict.Client/"]
COPY ["src/Modules/Shared/Bistrotic.OpenIdDict.Shared/Bistrotic.OpenIdDict.Shared.csproj", "src/Modules/Shared/Bistrotic.OpenIdDict.Shared/"]
COPY ["src/Modules/Server/Bistrotic.OpenIdDict.Server/Bistrotic.OpenIdDict.Server.csproj", "src/Modules/Server/Bistrotic.OpenIdDict.Server/"]
RUN dotnet restore "src/Programs/Server/Bistrotic.Server.csproj"
COPY . .
WORKDIR "/src/src/Programs/Server"
RUN dotnet build "Bistrotic.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bistrotic.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["/Certificates/BistroticEncryptionCertificate.pfx", "app/publish/"]
COPY ["/Certificates/BistroticSigningCertificate.pfx", "app/publish/"]
ENTRYPOINT ["dotnet", "Bistrotic.Server.dll"]