# DeveloperStoreBack

## Descrição do Projeto BackEnd

O **DeveloperStoreBack** é uma aplicação que segue os princípios do Domain-Driven Design (DDD) e é construída com .NET 9.0. 
O projeto fornece uma API para gerenciar vendas, produtos e clientes, utilizando MongoDB como banco de dados.

## Estrutura do Projeto

A estrutura do projeto é organizada em camadas conforme o padrão DDD:
DeveloperStoreBack 
│ ├── DeveloperStoreBack.Tests # Testes da aplicação 
│ ├── Integration # Testes de integração 
│ ├── Unit # Testes unitários 
│ │ ├── Controllers 
│ │ ├── Repositories 
│ │ └── Services 
│ └── SaleServiceTests.cs 
│ └── src 
├── Api # Camada de apresentação (API) 
│ ├── Controllers # Controladores da API 
│ ├── Properties # Configurações da API 
│ └── Program.cs # Ponto de entrada da aplicação 
│ ├── Application # Camada de aplicação (casos de uso) 
│ ├── DTOs # Objetos de transferência de dados 
│ ├── Services # Lógica de aplicação 
│ └── DeveloperStoreBack.Application.csproj 
│ ├── Domain # Camada de domínio (entidades, agregados, repositórios) 
│ ├── Entities # Entidades do domínio 
│ ├── Enums # Enumeradores do domínio 
│ └── Repositories # Interfaces de repositórios 
│ ├── IItemRepository.cs 
│ ├── ISaleRepository.cs 
│ └── IUserRepository.cs 
│ └── Infrastructure # Camada de infraestrutura (implementações de repositórios, serviços externos)

### Tecnologias Utilizadas

- **.NET 9.0**: Plataforma para desenvolvimento de aplicações web.
- **MongoDB**: Banco de dados NoSQL utilizado para armazenar dados.
- **Swagger**: Ferramenta para documentação e teste de APIs.
- **xUnit**: Framework de testes para .NET.
- **Moq**: Biblioteca para criação de mocks em testes unitários.

## Clonando o Projeto

Para clonar o projeto, siga os passos abaixo:

1. Abra o terminal (ou Prompt de Comando).
2. Navegue até o diretório onde você deseja clonar o projeto.
3. Execute o seguinte comando:

```bash
git clone https://github.com/EuderAlves/developerStore.git

cd developerStore/DeveloperStoreBack

## Executando o Projeto

Para executar o projeto, siga os passos abaixo:

Certifique-se de que você tenha o .NET 9.0 e o MongoDB instalados.
Execute o comando de restauração para instalar as dependências:

```bash
dotnet restore

Inicie o MongoDB, se ainda não estiver em execução.
Execute o projeto:

```bash
dotnet run --project src/Api

Acesse a API no navegador através do seguinte endereço:
http://localhost:5000

## Usando o Swagger

Após iniciar a aplicação, você pode acessar a documentação da API através do Swagger. Vá para:

http://localhost:5000/swagger
Aqui, você pode visualizar todos os endpoints disponíveis e testar cada um deles.
# Item
![image](https://github.com/user-attachments/assets/30db3231-ca62-4c4d-9ac1-41ec86160ca8)
# Sale
![image](https://github.com/user-attachments/assets/38daf867-f7ef-4946-a08c-aa52a8b89f95)
# User
![image](https://github.com/user-attachments/assets/68e058f1-be6e-444b-8e57-5bad9b0b2074)
