# API Documentation - RechargeTower

## Base URL
`https://localhost:7000`

## Endpoints

### 🟢 GET /api/User
**Retorna todos os usuários (JÁ EXISTEM 6 CADASTRADOS)**
```json
[
  {
    "id": 1,
    "name": "Admin",
    "email": "admin@torres.com"
  },
  {
    "id": 2, 
    "name": "Usuário",
    "email": "usuario@torres.com"
  }
  // ... mais usuários
]
```

### POST /api/Product
{
  "Id": "54",
  "name": "TorreLuan",
  "Localizacao": "Paralela"
}
