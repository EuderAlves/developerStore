# Use a imagem base do SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Defina o diretório de trabalho
WORKDIR /app

# Copie o arquivo .csproj e restaure as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie o restante dos arquivos e construa o projeto
COPY . .
RUN dotnet publish -c Release -o out

# Use a imagem base do runtime do .NET
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Defina o diretório de trabalho
WORKDIR /app

# Copie os arquivos publicados da etapa de build
COPY --from=build /app/out .

# Defina a porta que a aplicação irá escutar
ENV ASPNETCORE_URLS=http://+:80

# Exponha a porta
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "DeveloperStoreBack.Api.dll"]