FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "Quizi.sln"

RUN dotnet publish "Source/Host/Host.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT: Production
ENV ASPNETCORE_URLS: ${ASPNETCORE_URLS}

ENV Main__Name: api
ENV Main__CorsOrigin: ${Main__CorsOrigin}

ENV Database__ConnectionString: ${Database__ConnectionString}

ENV Identity__Issuer: ${Identity__Issuer}
ENV Identity__Audience: ${Identity__Audience}
ENV Identity__AccessTokenSecretKey: ${Identity__AccessTokenSecretKey}
ENV Identity__RefreshTokenSalt: ${Identity__RefreshTokenSalt}

EXPOSE 8080

ENTRYPOINT ["dotnet", "Host.dll"]
