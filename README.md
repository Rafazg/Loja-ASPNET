# MinhaApi - API Monolítica em Camadas

API REST monolítica com arquitetura em camadas usando ASP.NET Core 8, Entity Framework Core e SQL Server.

## 🏗️ Arquitetura

```
MinhaApi.API           → Controllers (Presentation)
MinhaApi.Application   → Services, DTOs, AutoMapper
MinhaApi.Domain        → Entidades, Interfaces, Regras de Negócio
MinhaApi.Infrastructure→ DbContext, EF Core, Repositories
MinhaApi.CrossCutting  → Injeção de Dependência (IoC)
```

## 🚀 Como Executar

### 1. Pré-requisitos
- .NET 8 SDK
- SQL Server (LocalDB ou Docker)

### 2. Configurar Connection String
Edite `src/MinhaApi.API/appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MinhaApiDb;User Id=sa;Password=SuaSenha;TrustServerCertificate=True;"
}
```

### 3. Criar Banco de Dados
```bash
cd src/MinhaApi.API
dotnet ef migrations add InitialCreate --project ../MinhaApi.Infrastructure --startup-project .
dotnet ef database update --project ../MinhaApi.Infrastructure --startup-project .
```

### 4. Rodar a API
```bash
dotnet run --project src/MinhaApi.API
```
Acesse: https://localhost:7000/swagger

## 📡 Endpoints

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/produtos` | Listar todos |
| GET | `/api/produtos/{id}` | Obter por ID |
| POST | `/api/produtos` | Criar produto |
| PUT | `/api/produtos/{id}` | Atualizar produto |
| DELETE | `/api/produtos/{id}` | Remover (soft delete) |

## 📦 Exemplo de Requisição POST
```json
{
  "nome": "Notebook Dell",
  "descricao": "Notebook i7 16GB RAM",
  "preco": 4500.00,
  "quantidadeEstoque": 10
}
```
