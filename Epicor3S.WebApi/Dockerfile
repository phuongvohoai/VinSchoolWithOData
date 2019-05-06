FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY VinSchool.Api/VinSchool.Api.csproj VinSchool.Api/
RUN dotnet restore VinSchool.Api/VinSchool.Api.csproj
COPY . .
WORKDIR /src/VinSchool.Api
RUN dotnet build VinSchool.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish VinSchool.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VinSchool.Api.dll"]
