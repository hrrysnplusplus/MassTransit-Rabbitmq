#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HomeOwnerService/HomeOwnerService.csproj", "HomeOwnerService/"]
RUN dotnet restore "HomeOwnerService/HomeOwnerService.csproj"
COPY . .
WORKDIR "/src/HomeOwnerService"
RUN dotnet build "HomeOwnerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeOwnerService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeOwnerService.dll"]