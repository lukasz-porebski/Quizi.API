FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS runtime
WORKDIR /app

RUN apk add --no-cache icu-data-full icu-libs

COPY publish/ ./

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV LC_ALL=pl_PL.UTF-8
ENV LANG=pl_PL.UTF-8

EXPOSE ${PORT:-8080}

ENTRYPOINT ["dotnet", "Host.dll"]