### Resumo dos Endpoints

| Método HTTP | Endpoint | Descrição |
| --- | --- | --- |
| GET | /api/items | Listar todos os itens |
| GET | /api/items/{id} | Obter detalhes de um item específico |
| POST | /api/items | Criar um novo item |
| GET | /api/buyers | Listar todos os compradores |
| GET | /api/buyers/{id} | Obter detalhes de um comprador específico |
| POST | /api/buyers | Criar um novo comprador |
| GET | /api/sellers | Listar todos os vendedores |
| GET | /api/sellers/{id} | Obter detalhes de um vendedor específico |
| POST | /api/sellers | Criar um novo vendedor |
| POST | /api/bids | Colocar um lance em um item |
| GET | /api/bids/{id} | Obter detalhes de um lance específico |

# 1. Endpoints para Itens

## a. Listar todos os itens

### GET /api/items
```bash
GET /api/items HTTP/1.1
Host: your-api-url
curl -X GET "https://your-api-url/api/items"
```

## b. Obter detalhes de um item específico

### GET /api/items/{id}
```bash
GET /api/items/1 HTTP/1.1
Host: your-api-url
curl -X GET "https://your-api-url/api/items/1"
```

## c. Criar um novo item

### POST /api/items
```bash
POST /api/items HTTP/1.1
Host: your-api-url
Content-Type: application/json

{
    "description": "Antique Vase",
    "startingBid": 50.00,
    "auctionEndTime": "2024-06-10T14:00:00Z",
    "sellerId": 1
}
```

# 2. Endpoints para Compradores

## a. Listar todos os compradores

### GET /api/buyers
```bash
GET /api/buyers HTTP/1.1
Host: your-api-url
curl -X GET "https://your-api-url/api/buyers"
```

## b. Obter detalhes de um comprador específico

### GET /api/buyers/{id}
```bash
GET /api/buyers/1 HTTP/1.1
Host: your-api-url
curl -X GET "https://your-api-url/api/buyers/1"
```

## c. Criar um novo comprador

### POST /api/buyers
```bash
POST /api/buyers HTTP/1.1
Host: your-api-url
Content-Type: application/json

{
    "name": "John Doe"
}
```

# 3. Endpoints para Vendedores

## a. Listar todos os vendedores

### GET /api/sellers
```bash
GET /api/sellers HTTP/1.1
Host: your-api-url
curl -X GET "https://your-api-url/api/sellers"
```

## b. Obter detalhes de um vendedor específico

### GET /api/sellers/{id}
```bash
GET /api/sellers/1 HTTP/1.1
Host: your-api-url
curl -X GET "https://your-api-url/api/sellers/1"
```

## c. Criar um novo vendedor

### POST /api/sellers
```bash
POST /api/sellers HTTP/1.1
Host: your-api-url
Content-Type: application/json

{
    "name": "Alice Johnson"
}
```

# 4. Endpoints para Lances

## a. Colocar um lance em um item

### POST /api/bids
```bash
POST /api/bids HTTP/1.1
Host: your-api-url
Content-Type: application/json

{
    "amount": 60.00,
    "time": "2024-06-08T12:00:00Z",
    "itemId": 1,
    "buyerId": 1
}
```

## b. Obter detalhes de um lance específico

### GET /api/bids/{id}
```bash
GET /api/bids/1 HTTP/1.1
Host: your-api-url
curl -X GET "https://your-api-url/api/bids/1"
```