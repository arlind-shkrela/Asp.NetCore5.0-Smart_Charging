#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Smart_ChargingApi/Smart_ChargingApi.csproj", "Smart_ChargingApi/"]
RUN dotnet restore "Smart_ChargingApi/Smart_ChargingApi.csproj"
COPY . .
WORKDIR "/src/Smart_ChargingApi"
RUN dotnet build "Smart_ChargingApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Smart_ChargingApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smart_ChargingApi.dll"]