FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["maskify.api/maskify.api.csproj", "maskify.api/"]
COPY ["maskify.core/maskify.core.csproj", "maskify.core/"]
COPY ["maskify.models/maskify.models.csproj", "maskify.models/"]
RUN dotnet restore "maskify.api/maskify.api.csproj"
COPY . .
WORKDIR "/src/maskify.api"
RUN dotnet build "maskify.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "maskify.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "maskify.api.dll"]