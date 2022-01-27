FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Api.Cliente/Api.Cliente.csproj", "Api.Cliente/"]
COPY ["Api.Cliente.Business/Api.Cliente.Business.csproj", "Api.Cliente.Business/"]
COPY ["Api.Cliente.Domain/Api.Cliente.Domain.csproj", "Api.Cliente.Domain/"]
COPY ["Api.Cliente.Data/Api.Cliente.Data.csproj", "Api.Cliente.Data/"]
RUN dotnet restore "Api.Cliente/Api.Cliente.csproj"
COPY . .
WORKDIR "/src/Api.Cliente"
RUN dotnet build "Api.Cliente.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Cliente.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Cliente.dll"]
