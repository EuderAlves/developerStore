# Use a imagem base do SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Defina o diretório de trabalho
WORKDIR /app

# Copie os arquivos .csproj de todos os projetos
COPY Application/*.csproj ../Application/
COPY Domain/*.csproj ../Domain/
COPY Infrastructure/*.csproj ../Infrastructure/
COPY Api/*.csproj ../Api/

# Restaure as dependências
RUN dotnet restore ./Api/DeveloperStoreBack.Api.csproj

# Copie o restante dos arquivos e construa o projeto
COPY . .
RUN dotnet publish ./Api/DeveloperStoreBack.Api.csproj -c Release -o out

# Use a imagem base do runtime do .NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

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