# Loja ASPNET - Arquitetura de Microserviços com BFF

Projeto de estudo utilizando arquitetura de microserviços com ASP.NET Core 8, comunicação HTTP entre serviços e padrão BFF (Backend For Frontend).

---

# 🏗️ Arquitetura

```text
Frontend
   ↓
BFF API
   ↓
Product API
Cart API
```

---

# Microserviços

## 🔹 BFF API
Responsável por centralizar as chamadas do frontend para os microserviços.

### Responsabilidades
- Agregar respostas
- Encapsular comunicação entre serviços
- Expor endpoints simplificados ao frontend

---

## 🔹 Product API
Responsável pelo gerenciamento de produtos.

### Funcionalidades
- Criar produto
- Atualizar produto
- Buscar produtos
- Buscar produto por ID
- Remover produto

---

## 🔹 Cart API
Responsável pelo gerenciamento do carrinho de compras.

### Funcionalidades
- Adicionar item ao carrinho
- Remover item
- Listar itens do carrinho

---

# Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- HttpClient
- Swagger/OpenAPI
- AutoMapper

---

# 📁 Estrutura do Projeto

```text
src/
│
├── BffApi/
│
├── ProductApi/
│   ├── Controllers
│   ├── Application
│   ├── Domain
│   ├── Infrastructure
│   └── CrossCutting
│
└── CartApi/
```

---

#  Comunicação Entre Serviços

O BFF se comunica com os microserviços via HTTP utilizando `HttpClient`.

Exemplo:

```text
Frontend → BFF → Product API
Frontend → BFF → Cart API
```

---

#  Como Executar

## 1. Pré-requisitos

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 ou VS Code

---

## 2. Configurar Connection Strings

### Product API

Edite:

```text
src/ProductApi/appsettings.json
```

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ProductDb;User Id=sa;Password=SuaSenha;TrustServerCertificate=True;"
}
```

---

## 3. Executar Migrations

### Product API

```bash
cd src/ProductApi

dotnet ef migrations add InitialCreate --project ../MinhaApi.Infrastructure --startup-project .

dotnet ef database update --project ../MinhaApi.Infrastructure --startup-project .
```

---

## 4. Executar os Serviços

### Product API

```bash
dotnet run --project src/ProductApi
```

---

### Cart API

```bash
dotnet run --project src/CartApi
```

---

### BFF API

```bash
dotnet run --project src/BffApi
```

---

#  Endpoints

## 🔹 Product API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/produtos` | Listar produtos |
| GET | `/api/produtos/{id}` | Buscar por ID |
| POST | `/api/produtos` | Criar produto |
| PUT | `/api/produtos/{id}` | Atualizar produto |
| DELETE | `/api/produtos/{id}` | Remover produto |

---

## 🔹 Cart API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/cart` | Listar carrinho |
| POST | `/api/cart/items` | Adicionar item |
| DELETE | `/api/cart/items/{productId}` | Remover item |

---

## 🔹 BFF API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/bff/products` | Retorna produtos |
| GET | `/bff/products/{id}` | Retorna produto por ID |
| GET | `/bff/cart` | Retorna carrinho |
| POST | `/bff/cart/items` | Adiciona item ao carrinho |

---

#  Exemplo de Requisição - Criar Produto

```json
{
  "nome": "Notebook Dell",
  "descricao": "Notebook i7 16GB RAM",
  "preco": 4500.00,
  "quantidadeEstoque": 10
}
```

---

#  Objetivos do Projeto

- Praticar arquitetura de microserviços
- Implementar comunicação entre APIs
- Aprender padrão BFF
- Aplicar separação de responsabilidades
- Evoluir futuramente para:
  - RabbitMQ
  - API Gateway
  - JWT
  - Docker
  - Kubernetes
  - Observabilidade
```
