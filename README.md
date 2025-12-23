# Product Inventory API
API REST desarrollada en **.NET 8** para la gestión de inventarios, productos, categorías y movimientos de inventario, con autenticación basada en **JWT** y persistencia en **SQL Server**, se implementa una arquitectura con los principios de SOLID
---
## Descripción
La API permite:
- Autenticación de usuarios mediante JWT
- Gestión de inventario (CRUD)
- Registro de movimientos de inventario
- Gestión de productos y categorías
- Protección de endpoints mediante autorización
- Manejo de sesiones activas por usuario para tener un mejor control y registro de accesos
---
## Arquitectura
El proyecto sigue una arquitectura en capas:
src/
ProductInventory.Api
ProductInventory.Application
ProductInventory.Domain
ProductInventory.Infrastructure
### Responsabilidades
|     Capa       |          Descripción             |
|----------------|----------------------------------|
| Api            | Exposición de endpoints HTTP     |
| Application    | Lógica de negocio y orquestación |
| Domain         | Entidades y reglas del dominio   |
| Infrastructure | Acceso a datos y persistencia    |
---
## Autenticación (JWT)
La API utiliza **JWT Bearer Authentication**:
- El token se genera al hacer login
- Incluye los claims:
  - `sub` - Id del usuario
  - `email`
- Los endpoints protegidos usan `[Authorize]`
- El token **expira automáticamente** y es validado en cada request
---
### Local
- .NET SDK 8.0+
- Docker y Docker Compose
### Puertos por defecto
- API: `http://localhost:5157`
- SQL Server: `1433`
---
## Ejecución con Docker
El proyecto puede ejecutarse completamente con Docker:
```
docker compose up --build
```
Esto realiza:
Creación del contenedor de SQL Server
Ejecución de scripts SQL (tablas, triggers, datos iniciales)
Levantamiento de la API
Acceso a Swagger
http://localhost:5157/swagger
## Ejecucion de pruebas 
Las pruebas unitarias estan en
tests/ProductInventory.Tests
Para la ejecucion se debe ejecutar el comando
	dotnet test
Autenticación
Método	   |  Endpoint
POST       |  /api/auth/login
Inventario
Método     |  Endpoint
GET	       |  /api/inventory
POST       |  /api/inventory
PUT	       |  /api/inventory/{id}
DELETE     |  /api/inventory/{id}
Movimientos de inventario
Método     |   Endpoint
GET        |  /api/inventory
POST       |  /api/inventory
