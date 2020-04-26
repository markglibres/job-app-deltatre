FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY ["DeltaTre.Presentation.Api/DeltaTre.Presentation.Api.csproj", "DeltaTre.Presentation.Api/"]
RUN dotnet restore "DeltaTre.Presentation.Api/DeltaTre.Presentation.Api.csproj"

COPY . .

WORKDIR "/src/DeltaTre.Presentation.Api"
RUN dotnet build "DeltaTre.Presentation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeltaTre.Presentation.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeltaTre.Presentation.Api.dll"]