# LAFT — Sistema web de análisis de riesgo

> **Lavado de Activos y Financiamiento del Terrorismo** · Aplicación ASP.NET MVC pensada para apoyar la prevención y el análisis de riesgo en entornos regulados (Costa Rica y marcos similares).

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8.1-512BD4?style=flat-square)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5-239120?style=flat-square)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-6-9333EA?style=flat-square)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019%2B-CC2927?style=flat-square)

---

## Qué es este proyecto

**LAFT** es una solución web que **automatiza parte del análisis de riesgo** cruzando información de **personas** (físicas y jurídicas) con **actividades financieras**, **palabras clave** y **archivos de análisis**. El motor de reglas evalúa coincidencias y actividades asociadas para sugerir un **nivel de riesgo** y dejar **trazabilidad** (bitácora de eventos).

No sustituye el criterio de un oficial de cumplimiento ni un dictamen legal: es una **herramienta de apoyo** alineada con buenas prácticas de desarrollo en capas.

---

## Por qué está “tuanis” a nivel técnico

| Enfoque | Detalle |
|--------|---------|
| **Arquitectura en capas** | Separación clara entre UI, lógica de negocio, acceso a datos y contratos (`Abstracciones`). |
| **SOLID y Clean Code** | Interfaces por módulo, responsabilidades acotadas, nombres expresivos. |
| **ASP.NET Identity** | Usuarios, roles y cookies con OWIN; autorización por roles en módulos sensibles. |
| **Entity Framework 6** | Mapeo objeto-relacional sobre SQL Server. |
| **UI** | Bootstrap 5, Razor, DataTables en listados; identidad visual oscura tipo “terminal / LAFT”. |

---

## Estructura del repositorio

```
LAFT/
├── LAFT.UI/                 # Capa de presentación (MVC, vistas, contenido estático)
├── LAFT.LN/                 # Lógica de negocio (análisis, registro, listados…)
├── LAFT.AccesoADatos/       # EF + repositorios / consultas por módulo
├── LAFT.Abstracciones/      # DTOs, interfaces y modelos de tablas compartidos
├── Database/
│   └── LAFTDB.sql           # Script de base de datos (esquema / datos de referencia)
├── LAFT.UI.sln              # Solución Visual Studio
└── README.md                # Este archivo
```

---

## Módulos principales

| Módulo | Descripción breve |
|--------|-------------------|
| **Personas** | Alta, edición, listado y detalle; vínculo con análisis por persona. |
| **Actividades financieras** | Catálogo de actividades y nivel de riesgo asociado (rol Administrador). |
| **Actividades por persona** | Asignación de actividades financieras a una persona concreta. |
| **Archivos de análisis** | Carga y gestión de textos/fuentes usados en el cruce con datos de clientes. |
| **Palabras clave** | Lista de términos buscados dentro del contenido de archivos. |
| **Análisis** | Ejecución del análisis por persona, historial y listado de personas analizadas. |
| **Bitácora de eventos** | Registro de acciones relevantes (p. ej. actualizaciones). |
| **Cuentas** | Registro, inicio de sesión y administración de perfil (Identity). |

---

## Requisitos previos

- **Windows** (recomendado para IIS Express / Visual Studio).
- **Visual Studio 2019/2022** con carga de trabajo **ASP.NET y desarrollo web**.
- **SQL Server** (LocalDB, Express o instancia completa) accesible desde la máquina.
- **.NET Framework 4.8.1** (Developer Pack si el IDE lo solicita).

---

## Base de datos

### Cadena de conexión

En `LAFT.UI/Web.config`, la clave **`Contexto`** apunta por defecto a:

```xml
Data Source=(local); Initial Catalog=LAFT; Integrated Security=True
```

Ajusta **`Data Source`** a tu instancia (`(localdb)\MSSQLLocalDB`, `.\SQLEXPRESS`, etc.) si hace falta.

> Tanto el **contexto EF del dominio** como **ASP.NET Identity** (`ApplicationDbContext`) usan la misma cadena **`Contexto`**, así que usuarios y tablas LAFT conviven en la base **`LAFT`** (según tu script y migraciones).

### Script `Database/LAFTDB.sql`

Incluye la creación de la base y objetos. **Ojo:** un script generado desde SSMS puede traer **rutas fijas** a archivos `.mdf` / `.ldf` en tu disco. Si falla al ejecutarlo:

1. Crea la base **`LAFT`** desde SSMS con rutas válidas en tu equipo, **o**
2. Edita las rutas `FILENAME = N'...'` del script para que apunten a carpetas donde SQL Server tenga permiso, **o**
3. Restaura / adjunta según tu flujo habitual de despliegue.

Después de tener la base lista, vuelve a comprobar la cadena de conexión y ejecuta la aplicación.

---

## Autenticación y roles

- El registro público asigna por defecto el rol **`Cliente`**.
- Varias pantallas exigen **`Administrador`** o **`Analista`** (por ejemplo archivos de análisis, actividades persona, etc.).
- Si un usuario **ya inició sesión** pero **no tiene el rol**, la app evita un bucle infinito hacia Login y muestra un aviso en la página de inicio (filtro personalizado `AuthorizeRoles`).

**Para probar módulos restringidos:** en las tablas de Identity (`AspNetRoles`, `AspNetUserRoles`) asigna a tu usuario el rol **`Analista`** o **`Administrador`** (nombres exactos como en el código).

---

## Cómo ejecutar el proyecto

1. Clona el repositorio.
2. Abre **`LAFT.UI.sln`** en Visual Studio.
3. Restaura paquetes NuGet si es necesario (clic derecho en la solución → *Restore NuGet Packages*).
4. Prepara la base **`LAFT`** (script o manual) y verifica **`Web.config`**.
5. Establece **`LAFT.UI`** como proyecto de inicio y pulsa **F5** (IIS Express).

La carpeta **`Uploads`** (u otras rutas usadas en registro de archivos) debe existir o crearse según la lógica de los controladores en tu entorno.

---

## Buenas prácticas aplicadas

- Inyección de dependencias ligera mediante **constructores** y **interfaces** en la capa LN.
- **DTOs** para transporte entre capas; entidades de EF en Abstracciones / AD.
- Validación en cliente (jQuery Validate / unobtrusive) donde aplica.
- Manejo defensivo frente a referencias nulas en consultas y vistas críticas.

---

## Licencia y uso

El uso del código es responsabilidad de quien lo despliegue. Revisa políticas internas de datos personales y normativa LAFT/AML de tu jurisdicción antes de usar datos reales.

---

## Autora / equipo

Proyecto académico y de portafolio orientado a **desarrollo web**, **bases de datos** y **metodologías ágiles**, con énfasis en cumplimiento y análisis de riesgos.

---

**Pura vida y buen deploy.**
