FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS runtime
WORKDIR /app

RUN apk add --no-cache icu-data-full

COPY publish/ ./

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

EXPOSE ${PORT:-8080}

ENTRYPOINT ["dotnet", "Host.dll"]