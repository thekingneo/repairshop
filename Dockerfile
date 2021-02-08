FROM mcr.microsoft.com/dotnet/sdk:5.0-focal  AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY RepairShop.Server/RepairShop.Server.csproj ./RepairShop.Server/
COPY RepairShop.Shared/RepairShop.Shared.csproj ./RepairShop.Shared/
COPY RepairShop.Client/RepairShop.Client.csproj ./RepairShop.Client/


WORKDIR /app/RepairShop.Server/

RUN dotnet restore

WORKDIR /app

COPY RepairShop.Server/. ./RepairShop.Server
COPY RepairShop.Shared/. ./RepairShop.Shared
COPY RepairShop.Client/. ./RepairShop.Client


WORKDIR /app/RepairShop.Server/


RUN dotnet publish -c Release -o out


# Build runtime image
FROM  mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/RepairShop.Server/out ./
#ENTRYPOINT ["dotnet", "Commander.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet RepairShop.Server.dll