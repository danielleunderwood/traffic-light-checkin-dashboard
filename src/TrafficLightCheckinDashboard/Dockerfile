FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY TrafficLightCheckinDashboard/Dashboard.csproj TrafficLightCheckinDashboard/Dashboard.csproj
COPY Core/Core.csproj Core/Core.csproj
COPY Repository/Repository.csproj Repository/Repository.csproj
RUN dotnet restore TrafficLightCheckinDashboard/Dashboard.csproj
COPY . .
RUN dotnet build TrafficLightCheckinDashboard/Dashboard.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish TrafficLightCheckinDashboard/Dashboard.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
