# Developer Store Backend

## Estrutura
developerStoreBack/
├── src/
│   ├── Api/
│   │   ├── Controllers/
│   │       └── UserController.cs
│   │   └── Program.cs
│   ├── Application/
│   │   ├── DTOs/
│   │       └── UserLoginDto.cs
│   │   ├── Services/           // Adicionada a pasta Services
│   │       └── UserService.cs
│   ├── Domain/
│   │   └── Entities/
│   │       └── User.cs
│   ├── Infrastructure/
│   │   └── Data/
│   │       └── Contexts/
│   │           └── MongoDbContext.cs
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