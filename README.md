# DeveloperStoreBack

## Descrição do Projeto BackEnd

O **DeveloperStoreBack** é uma aplicação que segue os princípios do Domain-Driven Design (DDD) e é construída com .NET 9.0. 
O projeto fornece uma API para gerenciar vendas, produtos e clientes, utilizando MongoDB como banco de dados.

## Estrutura do Projeto
## Estrutura do Projeto

- **DeveloperStoreBack**: Raiz do projeto.
- **DeveloperStoreBack.Tests**: Contém todos os testes, organizados em subpastas para testes unitários, de integração e resultados.
- **src**: Contém a lógica da aplicação, dividida em várias camadas:
  - **Api**: Camada de apresentação, onde estão os controladores e a configuração da aplicação.
  - **Application**: Contém a lógica de aplicação e casos de uso, incluindo DTOs e serviços.
  - **Domain**: Define as entidades e repositórios do domínio, seguindo os princípios do DDD.
  - **Infrastructure**: Implementações concretas de repositórios e serviços externos, como acesso a banco de dados.

A estrutura do projeto é organizada em camadas conforme o padrão DDD:
DeveloperStoreBack
│
├── DeveloperStoreBack.Tests           # Testes da aplicação
│   ├── bin                             
│   ├── coverage-report                 
│   ├── Integration                    
│   ├── obj                             
│   ├── TestResults                     # Resultados dos testes
│   └── Unit                            # Testes unitários
│       ├── Controllers
│       ├── Repositories
│       ├── Services
│       └── DeveloperStoreBack.Tests.csproj
│
└── src
    ├── Api                             # Camada de apresentação (API)
    │   ├── bin                         
    │   ├── Controller                  # Controladores da API
    │   ├── obj                         
    │   ├── Properties                  # Arquivos de propriedades
    │   │   ├── appsettings.Development.json
    │   │   └── appsettings.json
    │   ├── DeveloperStoreBack.Api.csproj
    │   └── Program.cs                  # Ponto de entrada da aplicação
    │
    ├── Application                      # Camada de aplicação (casos de uso)
    │   ├── bin                         
    │   ├── DTOs                        # Objetos de transferência de dados
    │   ├── obj                        
    │   └── Services                    # Lógica de aplicação
    │       └── DeveloperStoreBack.Application.csproj
    │
    ├── Domain                           # Camada de domínio (entidades, agregados, repositórios)
    │   ├── bin                         
    │   ├── Entities                     # Entidades do domínio
    │   ├── Enums                        # Enumeradores do domínio
    │   ├── obj                         
    │   └── Repositories                 # Interfaces de repositórios
    │       └── DeveloperStoreBack.Domain.csproj
    │
    └── Infrastructure                   # Camada de infraestrutura (implementações de repositórios, serviços externos)
        ├── bin                        
        ├── Data                         # Classes relacionadas a dados
        │   └── Contexts                 # Contextos do banco de dados (ex: DbContext)
        └── Repositories                 # Implementações de repositórios

## Conclusão
Esta estrutura permite uma separação clara de preocupações e facilita a manutenção e a escalabilidade do projeto.

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
![image](https://github.com/user-attachments/assets/2ada7d0e-e7dc-4d77-a5a8-31e94b8a6293)
# Sale
![image](https://github.com/user-attachments/assets/38daf867-f7ef-4946-a08c-aa52a8b89f95)
# User
![image](https://github.com/user-attachments/assets/68e058f1-be6e-444b-8e57-5bad9b0b2074)
