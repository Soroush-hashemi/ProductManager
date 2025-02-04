FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGUATION=Release
WORKDIR /src
COPY ["/ProductManager/ProductManager.csproj" , "."]

RUN dotnet restore "ProductManager.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "." -c ${BUILD_CONFIGUATION} -o /app/build

FROM build AS publish
ARG BUILD_CONFIGUATION=Release
RUN dotnet publish "." -c ${BUILD_CONFIGUATION} -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductManager.dll"]