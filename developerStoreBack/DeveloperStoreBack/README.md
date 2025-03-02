# Developer Store Backend

## Estrutura
developerStoreBack/
├── src/
│   ├── Api/
│   │   ├── Controllers/
│   │       └── ItemController.cs  // Controlador para os itens
│   ├── Application/
│   │   ├── DTOs/
│   │       └── ItemDto.cs          // DTO para itens
│   │   ├── Services/
│   │       └── ItemService.cs      // Serviço para gerenciamento de itens
│   ├── Domain/
│   │   ├── Entities/
│   │       └── Item.cs             // Entidade para itens
│   │   ├── Repositories/
│   │       └── IItemRepository.cs   // Interface do repositório de itens
│   ├── Infrastructure/
│   │   └── Data/
│   │       └── Repositories/
│   │           └── ItemRepository.cs // Implementação do repositório de itens
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