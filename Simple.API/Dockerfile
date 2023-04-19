FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Simple.API/Simple.API.csproj", "Simple.API/"]
RUN dotnet restore "Simple.API/Simple.API.csproj"
COPY . .
WORKDIR "/src/Simple.API"
RUN dotnet build "Simple.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Simple.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simple.API.dll"]
