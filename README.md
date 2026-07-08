# 🏴‍☠️ One Piece API

API REST construida con **ASP.NET Core (.NET 10)** que actúa como *cliente/proxy* de la
[API pública de One Piece](https://api-onepiece.com/). El proyecto es un ejercicio práctico
para aprender a **consumir APIs externas** desde un backend en C# usando `HttpClient`,
inyección de dependencias y deserialización de JSON.

![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![ASP.NET Core Web API](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4)
![OpenAPI](https://img.shields.io/badge/OpenAPI-habilitada-6BA539?logo=openapiinitiative&logoColor=white)
![Licencia MIT](https://img.shields.io/badge/licencia-MIT-green)

> 🎓 Proyecto de práctica enfocado en la **comunicación entre APIs**: esta API recibe
> peticiones, consulta a la API de One Piece, mapea la respuesta a modelos propios
> (con nombres en español) y la devuelve al cliente.

---

## 🧭 ¿Qué hace?

El flujo de cada petición es:

```
Cliente  ─▶  OnePieceAPI (este proyecto)  ─▶  api-onepiece.com  ─▶  respuesta mapeada
```

Cada recurso sigue el mismo patrón:

- **Controller** → expone los endpoints HTTP.
- **Interface (`I...Service`)** → contrato del servicio.
- **Service** → consume la API externa con `HttpClient` y deserializa el JSON.
- **Model** → modelo propio en español, mapeado con `[JsonPropertyName]`.

---

## ✨ Recursos disponibles

| Recurso        | Ruta base                 | Fuente externa (api-onepiece.com) |
|----------------|---------------------------|-----------------------------------|
| Personajes     | `/api/Personaje`          | `/v2/characters/en`               |
| Espadas        | `/api/Espada`             | `/v2/swords/en`                   |
| Frutas         | `/api/Fruta`              | `/v2/fruits/en`                   |
| Tripulaciones  | `/api/Tripulacion`        | `/v2/crews/en`                    |
| Hakis          | `/api/Haki`               | `/v2/hakis/en`                    |
| Barcos         | `/api/Barco`              | `/v2/boats/en`                    |

Cada recurso ofrece **3 endpoints** con la misma estructura:

| Método | Endpoint                                | Descripción                                       |
|--------|-----------------------------------------|---------------------------------------------------|
| `GET`  | `/api/{Recurso}`                        | Obtiene **todos** los elementos.                  |
| `GET`  | `/api/{Recurso}/{id}`                   | Obtiene **un** elemento por su identificador.     |
| `GET`  | `/api/{Recurso}/multiple/{id1,id2,...}` | Obtiene **varios** elementos (IDs separados por coma). |

### Ejemplos

```http
GET /api/Personaje
GET /api/Personaje/1
GET /api/Personaje/multiple/1,2,3

GET /api/Fruta/multiple/5,8
GET /api/Tripulacion
GET /api/Haki/1
GET /api/Barco
GET /api/Barco/1
```

---

## 🛠️ Tecnologías

- [.NET 10](https://dotnet.microsoft.com/) / ASP.NET Core Web API
- `HttpClient` con **`IHttpClientFactory`** (`AddHttpClient<TInterface, TImpl>`)
- Inyección de dependencias
- Deserialización con `System.Text.Json` (`ReadFromJsonAsync`)
- **OpenAPI** habilitado en entorno de desarrollo

---

## 📂 Estructura del proyecto

```
OnePieceAPI/
├── Controllers/        # Endpoints HTTP (Personaje, Espada, Fruta, Tripulacion, Haki, Barco)
├── Services/           # Interfaces + servicios que consumen la API externa
├── Models/             # Modelos de datos mapeados desde el JSON externo
├── Program.cs          # Configuración, DI y registro de los HttpClient
├── OnePieceAPI.http    # Peticiones de ejemplo para probar la API
└── OnePieceAPI.csproj
```

---

## 🚀 Cómo ejecutarlo

### Requisitos

- [SDK de .NET 10](https://dotnet.microsoft.com/download)

### Pasos

```bash
# 1. Clonar el repositorio
git clone https://github.com/davidsored/OnePieceAPI.git
cd OnePieceAPI

# 2. Restaurar dependencias
dotnet restore

# 3. Ejecutar
dotnet run
```

Por defecto la API queda disponible en:

- HTTP  → `http://localhost:5278`
- HTTPS → `https://localhost:7102`

---

## 🧪 Probar la API

Puedes usar el archivo [`OnePieceAPI.http`](OnePieceAPI.http) (compatible con Visual Studio
y la extensión *REST Client* de VS Code), `curl`, Postman, o la documentación **OpenAPI**
disponible en desarrollo:

```
GET http://localhost:5278/openapi/v1.json
```

### Ejemplo real de request/response

Petición con `curl` (con la API corriendo en local):

```bash
curl http://localhost:5278/api/Personaje/1
```

Respuesta (`200 OK`, `application/json`):

```json
{
  "id": 1,
  "name": "Monkey D Luffy",
  "job": "Captain",
  "age": "19 ans",
  "bounty": "3.000.000.000",
  "status": "vivant",
  "crew": {
    "id": 1,
    "name": "The Chapeau de Paille crew",
    "description": null,
    "status": "assets",
    "number": "10",
    "roman_name": "Mugiwara no Ichimi",
    "total_prime": "3.161.000.100",
    "is_yonko": true
  },
  "fruit": {
    "id": 196,
    "name": "Hito Hito no Mi, Nika model",
    "roman_name": "Hito Hito no Mi, Moderu: Nika",
    "type": "Zoan Mythique",
    "description": "Hito Hito no Mi, Nika model, is a Mythical Zoan Demon Fruit that enables its user to transform into Nika, the \"God of the Sun\".",
    "filename": null,
    "technicalFile": null
  }
}
```

Dos detalles a tener en cuenta sobre esta respuesta:

- Las **claves** del JSON conservan los nombres de la API externa porque los modelos usan
  `[JsonPropertyName]`, que `System.Text.Json` aplica tanto al deserializar como al
  serializar; los nombres en español viven en las propiedades de los modelos C#
  (`Nombre`, `Recompensa`, `Tripulacion`...).
- Los **valores** llegan tal cual los devuelve [api-onepiece.com](https://api-onepiece.com/)
  (algunos campos vienen en francés, como `"age": "19 ans"`), por lo que pueden cambiar
  si la API externa actualiza sus datos.

---

## 📝 Notas

- Si un recurso no se encuentra, la API responde con **`404 Not Found`**.
- En los endpoints `multiple`, los identificadores no encontrados se omiten; solo se
  devuelve `404` si **ninguno** de los IDs existe.
- Este proyecto depende de la disponibilidad de la API externa
  [api-onepiece.com](https://api-onepiece.com/).

---

## 📄 Licencia

MIT — ver [LICENSE](./LICENSE).

---

## 📚 Créditos

Datos proporcionados por la API pública de **One Piece**: <https://api-onepiece.com/>

> One Piece © Eiichiro Oda / Shueisha. Este proyecto es solo con fines educativos.
