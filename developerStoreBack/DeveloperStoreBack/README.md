# Developer Store Backend

## Estrutura
developerStoreBack/
├── src/
│   ├── Api/
│   │   ├── Controllers/
│   │       └── UserController.cs
│   │       └── SaleController.cs  // Controlador para vendas
│   │   └── Program.cs
│   ├── Application/
│   │   ├── DTOs/
│   │       └── UserLoginDto.cs
│   │       └── SaleDto.cs          // DTO para vendas
│   │   ├── Services/
│   │       └── UserService.cs
│   │       └── SaleService.cs      // Serviço para vendas
│   ├── Domain/
│   │   ├── Entities/
│   │       └── User.cs
│   │       └── Sale.cs             // Entidade para vendas
│   │   ├── Repositories/
│   │       └── IUserRepository.cs  // Interface do repositório de usuários
│   │       └── ISaleRepository.cs   // Interface do repositório de vendas
│   ├── Infrastructure/
│   │   └── Data/
│   │       └── Contexts/
│   │           └── MongoDbContext.cs
│   │       └── Repositories/
│   │           └── UserRepository.cs // Implementação do repositório de usuários
│   │           └── SaleRepository.cs  // Implementação do repositório de vendas
└── ...
## Configuração

1. Clone o repositório.
2. Navegue até a pasta `DeveloperStoreBack`.
3. Execute `dotnet restore` para restaurar as dependências.
4. Para rodar a aplicação, use `dotnet run`.

## API

Acesse a documentação da API em `/swagger`.

## Banco de Dados



## Testes

Execute os testes com `dotnet test`.