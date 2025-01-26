# Usa a imagem oficial do .NET SDK para compilar e publicar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos da solução para dentro do contêiner
COPY . ./

# Restaura as dependências
RUN dotnet restore src/WebApi/WebApi.csproj

# Compila o projeto em modo Release
RUN dotnet publish src/WebApi/WebApi.csproj -c Release -o /app/publish

# Usa a imagem oficial do .NET Runtime para rodar o aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos publicados da etapa anterior
COPY --from=build /app/publish .

# Define a porta de exposição
EXPOSE 5000

# Configura a variável de ambiente para habilitar logs estruturados
ENV DOTNET_USE_POLLING_FILE_WATCHER=1

# Comando de entrada para rodar a aplicação
ENTRYPOINT ["dotnet", "WebApi.dll"]
