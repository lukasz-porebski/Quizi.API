FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS runtime
WORKDIR /app

COPY publish/ ./

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1

EXPOSE ${PORT:-8080}

ENTRYPOINT ["dotnet", "Host.dll"]