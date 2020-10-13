FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

ENV DOTNET_USE_POLLING_FILE_WATCHER=true  

RUN ["dotnet", "restore"]

ENTRYPOINT ["dotnet", "watch", "run", "URLS=http://+:80"]

