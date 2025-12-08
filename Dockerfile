# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution file if exists
COPY ["Eksamensplaner.sln", "./"]

# Copy csproj files and restore dependencies
COPY ["Eksamensplaner.Web/Eksamensplaner.Web.csproj", "Eksamensplaner.Web/"]
COPY ["Eksamensplaner.Core/Eksamensplaner.Core.csproj", "Eksamensplaner.Core/"]
COPY ["Eksamensplaner.Infrastructure/Eksamensplaner.Infrastructure.csproj", "Eksamensplaner.Infrastructure/"]

# Restore all projects
RUN dotnet restore "Eksamensplaner.Web/Eksamensplaner.Web.csproj"

# Copy everything else
COPY . .

# Build and publish (removed --no-restore to ensure all packages are available)
WORKDIR "/src/Eksamensplaner.Web"
RUN dotnet publish "Eksamensplaner.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Expose port (Render provides PORT environment variable)
EXPOSE 8080

# Copy published app
COPY --from=build /app/publish .

# Set environment variable for ASP.NET to listen on the port Render provides
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Eksamensplaner.Web.dll"]