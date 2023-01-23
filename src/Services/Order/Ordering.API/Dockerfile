#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Order/Ordering.API/Ordering.API.csproj", "src/Services/Order/Ordering.API/"]
COPY ["src/BuildingBlocks/Eventbus.Messages/Eventbus.Messages.csproj", "src/BuildingBlocks/Eventbus.Messages/"]
COPY ["src/Services/Order/Ordering.Application/Ordering.Application.csproj", "src/Services/Order/Ordering.Application/"]
COPY ["src/Services/Order/Ordering.Domain/Ordering.Domain.csproj", "src/Services/Order/Ordering.Domain/"]
COPY ["src/Services/Order/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "src/Services/Order/Ordering.Infrastructure/"]
RUN dotnet restore "src/Services/Order/Ordering.API/Ordering.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Order/Ordering.API"
RUN dotnet build "Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]