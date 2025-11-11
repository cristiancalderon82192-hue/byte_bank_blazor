# 🏦 ByteBank - Cliente Blazor WebAssembly

Aplicación frontend construida con Blazor WebAssembly para consumir la API REST de ByteBank. Proporciona una interfaz web moderna y reactiva para gestionar operaciones bancarias.

## 📊 Estado del Proyecto

### Funcionalidades Implementadas

| Módulo | Estado | Descripción |
|--------|--------|-------------|
| ✅ Cuentas | Implementado | Listar, ver detalle, eliminar cuentas |
| ✅ Movimientos | Implementado | Depósitos, Retiros, Transferencias |
| 🔜 Cuentahabientes | Pendiente | CRUD de clientes |
| 🔜 Préstamos | Pendiente | Gestión de préstamos |
| 🔜 Dashboard | Pendiente | Panel de control con estadísticas |
| 🔜 Reportes | Pendiente | Reportes y gráficos |

---

## 🛠️ Tecnologías

- **.NET 9.0** - Framework base
- **Blazor WebAssembly** - SPA que corre en el navegador
- **Bootstrap 5** - Framework CSS para estilos
- **HttpClient** - Cliente HTTP para consumir API REST

---

## 📦 Requisitos Previos

- **.NET 8 SDK** o superior
- **Navegador web moderno** (Chrome, Firefox, Edge)
- **API ByteBank** corriendo en `http://localhost:8000`

### Verificar instalación de .NET

```bash
dotnet --version
# Debería mostrar: 8.0.xxx o superior
```

---

## 🚀 Instalación y Configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/cristiancalderon82192-hue/byte_bank_blazor.git
cd byte_bank_blazor
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Configurar la URL de la API

Edita `Program.cs` si tu API corre en un puerto diferente:

```csharp
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:8000") // Cambiar si es necesario
});
```

También actualiza las URLs en los servicios (`Services/*.cs`):
- `CuentaService.cs`: `ApiBaseUrl`
- `MovimientoService.cs`: `ApiBaseUrl`

### 4. Ejecutar la aplicación

```bash
dotnet run
```

O para desarrollo con hot reload:

```bash
dotnet watch run
```

La aplicación estará disponible en: **http://localhost:5161**

---

## 📁 Estructura del Proyecto

```
byte_bank_blazor/
│
├── wwwroot/                      # 📂 Archivos estáticos
│   ├── css/                      # Estilos personalizados
│   ├── index.html               # HTML principal
│   └── favicon.ico
│
├── Models/                       # 📦 Modelos de datos (DTOs)
│   ├── Cuenta.cs                # Modelo de cuenta bancaria
│   ├── Cuentahabiente.cs        # Modelo de cliente
│   ├── Movimiento.cs            # Modelos de transacciones
│   └── ...
│
├── Services/                     # 🔧 Servicios para consumir API
│   ├── CuentaService.cs         # Operaciones con cuentas
│   ├── MovimientoService.cs     # Operaciones con movimientos
│   └── ...
│
├── Pages/                        # 📄 Páginas de la aplicación
│   ├── Index.razor              # Página principal
│   ├── Cuentas.razor            # Gestión de cuentas
│   ├── Movimientos.razor        # Transacciones bancarias
│   └── ...
│
├── Shared/                       # 🎨 Componentes compartidos
│   ├── MainLayout.razor         # Layout principal
│   ├── NavMenu.razor            # Menú de navegación
│   └── ...
│
├── Program.cs                    # ⚙️ Configuración de la app
├── App.razor                     # Componente raíz
├── _Imports.razor               # Imports globales
│
├── .gitignore
├── README.md                    # Este archivo
└── byte_bank_blazor.csproj     # Archivo de proyecto
```

---

## 🎯 Uso de la Aplicación

### 1. Página de Inicio

Accede a `http://localhost:5161` para ver la página principal.

### 2. Gestión de Cuentas

**URL:** `/cuentas`

**Funcionalidades:**
- ✅ Listar todas las cuentas bancarias
- ✅ Ver detalle de cada cuenta
- ✅ Eliminar cuentas
- ✅ Visualizar saldo y sobregiro

**Captura:**
```
+----+-------------------+---------------+-------------+------------+
| ID | Número de Cuenta  | Fecha Apertura| Saldo       | Acciones   |
+----+-------------------+---------------+-------------+------------+
| 1  | 1001234567890     | 15/01/2024    | $1,500,000  | Ver/Eliminar|
| 2  | 2009876543210     | 20/03/2024    | $5,000,000  | Ver/Eliminar|
+----+-------------------+---------------+-------------+------------+
```

### 3. Movimientos Bancarios

**URL:** `/movimientos`

**Funcionalidades:**

#### 💰 Depósitos
- Seleccionar cuenta
- Ingresar monto
- Agregar descripción opcional
- Actualiza saldo automáticamente

#### 💵 Retiros
- Seleccionar cuenta
- Ingresar monto
- Valida saldo disponible
- Controla sobregiros

#### 🔄 Transferencias
- Cuenta origen y destino
- Monto a transferir
- Validaciones automáticas
- Crea dos movimientos

---

## 🔌 Integración con la API

### Configuración de Servicios

Los servicios se configuran en `Program.cs`:

```csharp
// Registrar HttpClient
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:8000") 
});

// Registrar servicios personalizados
builder.Services.AddScoped<CuentaService>();
builder.Services.AddScoped<MovimientoService>();
```

### Ejemplo de Consumo de API

```csharp
// En CuentaService.cs
public async Task<List<Cuenta>?> GetCuentasAsync()
{
    return await _httpClient.GetFromJsonAsync<List<Cuenta>>("/api/cuentas");
}
```

### Manejo de Errores

Todos los servicios incluyen manejo de errores:

```csharp
try
{
    return await _httpClient.GetFromJsonAsync<Cuenta>($"{ApiBaseUrl}/{id}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    return null;
}
```

---

## 🧪 Pruebas

### Ejecutar en modo desarrollo

```bash
dotnet watch run
```

Esto habilitará hot reload - los cambios se reflejan automáticamente.

### Verificar que la API está corriendo

Antes de usar la aplicación Blazor, asegúrate de que la API está activa:

```bash
# En otra terminal
cd ../byte_bank_back
uvicorn app.main:app --reload
```

Verifica: http://localhost:8000/health

---

## 🎨 Personalización

### Cambiar estilos

Edita `wwwroot/css/app.css` para personalizar la apariencia:

```css
/* Ejemplo: Cambiar color del navbar */
.top-row {
    background-color: #1e3a8a;
}
```

### Agregar nuevas páginas

1. Crear archivo en `Pages/`:
```razor
@page "/nueva-pagina"

<h1>Mi Nueva Página</h1>

@code {
    // Lógica de la página
}
```

2. Agregar al menú en `Shared/NavMenu.razor`:
```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="nueva-pagina">
        <span class="oi oi-star" aria-hidden="true"></span> Nueva Página
    </NavLink>
</div>
```

---

## 🚢 Despliegue

### Opción 1: Publicar localmente

```bash
dotnet publish -c Release -o ./publish
```

Los archivos estarán en `./publish/wwwroot`

### Opción 2: Desplegar en GitHub Pages

```bash
# Agregar soporte para GitHub Pages
dotnet add package PublishSPAforGitHubPages.Build

# Publicar
dotnet publish -c Release
```

### Opción 3: Desplegar en Azure Static Web Apps

1. Ir a Azure Portal
2. Crear un Static Web App
3. Conectar con tu repositorio GitHub
4. Configurar build:
   - **App location**: `/`
   - **Api location**: `api` (si tienes)
   - **Output location**: `wwwroot`

### Opción 4: Desplegar en Netlify/Vercel

```bash
# Publicar
dotnet publish -c Release

# Subir la carpeta bin/Release/net8.0/publish/wwwroot
```

---

## 🔧 Troubleshooting

### Error: "CORS policy"

**Problema:** La API no permite peticiones desde el cliente Blazor.

**Solución:** Verifica que la API tenga CORS habilitado:

```python
# En FastAPI (main.py)
app.add_middleware(
    CORSMiddleware,
    allow_origins=["http://localhost:5161"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)
```

### Error: "Failed to fetch"

**Problema:** La API no está corriendo o la URL es incorrecta.

**Soluciones:**
1. Verifica que la API esté corriendo: `curl http://localhost:8000/health`
2. Revisa la URL en `Program.cs`
3. Revisa las URLs en los servicios

### Error: "Cannot read properties of null"

**Problema:** Los datos de la API son null.

**Solución:** Agrega verificaciones null en los componentes:

```razor
@if (cuentas == null)
{
    <p>Cargando...</p>
}
else if (!cuentas.Any())
{
    <p>No hay datos</p>
}
else
{
    <!-- Mostrar datos -->
}
```

---

## 📝 Próximas Funcionalidades

- [ ] Autenticación de usuarios
- [ ] Dashboard con gráficos
- [ ] Módulo de cuentahabientes completo
- [ ] Gestión de préstamos
- [ ] Reportes descargables (PDF/Excel)
- [ ] Notificaciones en tiempo real
- [ ] Modo oscuro
- [ ] Responsive design mejorado
- [ ] PWA (Progressive Web App)

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

---

## 👥 Autores

- **Cristian Arboleda** - *Desarrollo inicial* - [cristiancalderon82192-hue](https://github.com/cristiancalderon82192-hue)

---

## 🔗 Enlaces Útiles

- [Documentación de Blazor](https://docs.microsoft.com/es-es/aspnet/core/blazor/)
- [API Backend (FastAPI)](../byte_bank_back/README.md)
- [Bootstrap Documentation](https://getbootstrap.com/docs/5.3/)
- [.NET Documentation](https://docs.microsoft.com/es-es/dotnet/)

---

## 📊 Requisitos del Sistema

| Componente | Versión Mínima | Recomendada |
|------------|----------------|-------------|
| .NET SDK | 8.0 | 8.0 (latest) |
| RAM | 2 GB | 4 GB |
| Espacio en disco | 500 MB | 1 GB |
| Navegador | Chrome 90+ | Chrome/Edge (latest) |

