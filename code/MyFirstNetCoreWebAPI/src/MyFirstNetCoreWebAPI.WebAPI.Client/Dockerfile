FROM mcr.microsoft.com/dotnet/aspnet:2.1

# version de NSwager a instalar (se puede ver en los releases de Github)
ENV NSWAG_BUILD="1130" 

## Instalamos CURL
RUN apt-get update && apt-get install -y curl

## Descargamos el archivo de instalación, actualizamos e instalamos.
RUN curl -O -L https://github.com/RicoSuter/NSwag/releases/download/NSwag-Build-${NSWAG_BUILD}/NSwag.zip \
    && apt-get update \
    && apt-get install -y --no-install-recommends unzip \
    && unzip -q ./NSwag.zip -d NSwag \
    && apt-get remove -y --purge unzip \
    && rm -rf /var/lib/apt/lists/* \
    && rm -f NSwag.zip

## Creamos el directorio para utilizar al cargar el volumen externo y poder sacar los archivos generados
RUN mkdir resultado

## Copiamos los archivos necesarios
COPY ./ClientGenerator-docker-net.nswag ./
COPY ./openapispec.json ./openapispec.json

## Creamos los clientes
RUN dotnet NSwag/NetCore21/dotnet-nswag.dll run

## Entrypoint donde movemos los archivos creados a la carpeta que tenemos montada con el volumen externo
ENTRYPOINT ["/bin/mv", "MyAPIClient.cs", "MyAPIClient.ts", "./resultado"]