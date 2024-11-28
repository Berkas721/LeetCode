FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

LABEL APP="LeetCode.Api"
LABEL REPO="https://github.com/Berkas721/LeetCode"
LABEL VERSION="$VERSION"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/LeetCode.Api/LeetCode.Api.csproj", "src/LeetCode.Api/"]
COPY ["src/LeetCode.Dto/LeetCode.Dto.csproj", "src/LeetCode.Dto/"]
RUN dotnet restore "src/LeetCode.Api/LeetCode.Api.csproj"
COPY . .
WORKDIR "/src/src/LeetCode.Api"
RUN dotnet build "LeetCode.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LeetCode.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LeetCode.Api.dll"]
