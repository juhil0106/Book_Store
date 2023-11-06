#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Book/Book.API/Book.API.csproj", "Services/Book/Book.API/"]
COPY ["BuildingBlock/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlock/EventBus.Messages"]
RUN dotnet restore "Services/Book/Book.API/Book.API.csproj"
COPY . .
WORKDIR "/src/Services/Book/Book.API"
RUN dotnet build "Book.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Book.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Book.API.dll"]