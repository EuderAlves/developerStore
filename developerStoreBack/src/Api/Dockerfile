# Use a imagem base do SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Defina o diret�rio de trabalho
WORKDIR /app

# Copie os arquivos .csproj de todos os projetos
COPY src/Application/*.csproj ./Application/
COPY src/Domain/*.csproj ./Domain/
COPY src/Infrastructure/*.csproj ./Infrastructure/
COPY src/Api/*.csproj ./Api/

# Restaure as depend�ncias
RUN dotnet restore ./Api/DeveloperStoreBack.Api.csproj

# Copie o restante dos arquivos e construa o projeto
COPY src ./
RUN dotnet publish ./Api/DeveloperStoreBack.Api.csproj -c Release -o out

# Use a imagem base do runtime do .NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

# Defina o diret�rio de trabalho
WORKDIR /app

# Copie os arquivos publicados da etapa de build
COPY --from=build /app/out .

# Defina a porta que a aplica��o ir� escutar
ENV ASPNETCORE_URLS=http://+:80

# Exponha a porta
EXPOSE 80

# Comando para iniciar a aplica��o
ENTRYPOINT ["dotnet", "DeveloperStoreBack.Api.dll"]