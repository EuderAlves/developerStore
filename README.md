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
