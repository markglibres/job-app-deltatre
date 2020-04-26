FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DeltaTre.Search.Presentation.Rpc/DeltaTre.Search.Presentation.Rpc.csproj", "DeltaTre.Search.Presentation.Rpc/"]
RUN dotnet restore "DeltaTre.Search.Presentation.Rpc/DeltaTre.Search.Presentation.Rpc.csproj"

COPY . .

#TODO: use ls or find test projects and execute with xargs
#WORKDIR "/src/Tests/DeltaTre.Search.Domain.Tests"
#RUN dotnet test
#WORKDIR "/src/Tests/DeltaTre.Search.Application.Tests"
#RUN dotnet test
#WORKDIR "/src/Tests/DeltaTre.Search.Infrastructure.Tests"
#RUN dotnet test

WORKDIR "/src/DeltaTre.Search.Presentation.Rpc"
RUN dotnet build "DeltaTre.Search.Presentation.Rpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeltaTre.Search.Presentation.Rpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeltaTre.Search.Presentation.Rpc.dll"]