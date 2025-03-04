# DeveloperStoreBack

## Descrição do Projeto BackEnd

O **DeveloperStoreBack** é uma aplicação que segue os princípios do **Domain-Driven Design (DDD)** e é construída com **.NET 9.0**.  
O projeto fornece uma API para gerenciar vendas, produtos e clientes, utilizando **MongoDB** como banco de dados.

---

## Estrutura do Projeto

A estrutura segue os padrões de **DDD**, organizando o código em camadas claras:

```plaintext
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
```
Essa organização promove a separação de responsabilidades e facilita a manutenção e escalabilidade do projeto.

---

## Tecnologias Utilizadas

*   **.NET 9.0**: Plataforma para desenvolvimento de aplicações web.
*   **MongoDB**: Banco de dados NoSQL utilizado para armazenar dados.
*   **Swagger**: Ferramenta para documentação e teste de APIs.
*   **xUnit**: Framework de testes para .NET.
*   **Moq**: Biblioteca para criação de mocks em testes unitários.

---

## Clonando o Projeto

Para clonar o projeto, siga os passos abaixo:

`git clone https://github.com/EuderAlves/developerStore.git cd developerStore/DeveloperStoreBack`

---

## Executando o Projeto

Certifique-se de que você tenha o **.NET 9.0** e o **MongoDB** instalados.

1.  Restaure as dependências:
       
    `dotnet restore`
    
2.  Inicie o MongoDB, caso ainda não esteja em execução.
3.  Execute o projeto:
    
    `dotnet run --project src/Api`
    
4.  Acesse a API no navegador através do seguinte endereço: [http://localhost:5000](http://localhost:5000)

---

## Usando o Swagger

Após iniciar a aplicação, você pode acessar a documentação da API no **Swagger**.  
Acesse o endereço: [http://localhost:5000/swagger](http://localhost:5000/swagger).
A API do Swagger está exposta online na seguinte URL: [https://developerstore.onrender.com/index.html](https://developerstore.onrender.com/index.html)"


Aqui, você pode visualizar e testar todos os endpoints disponíveis.

---

## Exemplos de Rotas

### **Item**

![Item](https://github.com/user-attachments/assets/2ada7d0e-e7dc-4d77-a5a8-31e94b8a6293)

### **Sale**

![Sale](https://github.com/user-attachments/assets/38daf867-f7ef-4946-a08c-aa52a8b89f95)

### **User**

![User](https://github.com/user-attachments/assets/68e058f1-be6e-444b-8e57-5bad9b0b2074)
