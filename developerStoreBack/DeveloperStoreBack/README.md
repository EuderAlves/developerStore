# Developer Store Backend

## Estrutura
developerStoreBack/
├── src/
│   ├── Api/
│   │   ├── Controllers/
│   │       └── SaleController.cs
│   ├── Application/
│   │   ├── DTOs/
│   │       └── SaleDto.cs
│   │       └── SaleNotificationDto.cs // DTO para notificações
│   │   ├── Services/
│   │       └── SaleService.cs
│   │   └── Notifications/ // Nova pasta para gerenciar notificações
│   │       └── SaleNotificationService.cs // Serviço para gerenciar alertas
│   ├── Domain/
│   │   ├── Entities/
│   │       └── Sale.cs
│   │   ├── Repositories/
│   │       └── ISaleRepository.cs
│   ├── Infrastructure/
│   │   └── Data/
│   │       └── Repositories/
│   │           └── SaleRepository.cs
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