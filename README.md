# ByteBank - Cliente Blazor WebAssembly

Aplicación frontend construida con Blazor WebAssembly para consumir la API REST de ByteBank. Proporciona una interfaz web moderna y reactiva para gestionar operaciones bancarias.

## Funcionalidades

El sistema cuenta con los siguientes módulos completamente implementados:

### Gestión de Cuentas
- Listado de cuentas bancarias.
- Creación y edición de cuentas mediante formularios modales.
- Eliminación de cuentas con confirmación.
- Consulta de saldo y detalles.

### Gestión de Cuentahabientes
- Administración completa de clientes (CRUD).
- Búsqueda de clientes por documento de identidad.
- Formularios modales para registro y edición.
- Validación de datos.

### Movimientos Bancarios
- Registro de depósitos, retiros y transferencias.
- Interfaz unificada con ventanas modales para cada operación.
- Validación de saldos y límites.
- Historial de transacciones.

### Préstamos
- Solicitud y gestión de préstamos.
- Calculadora de cuotas con sistema de amortización francés.
- Visualización detallada de plazos e intereses.

### Gestión de Sucursales
- Administración de sucursales bancarias.
- Asociación con ciudades y tipos de sucursal.
- Interfaz basada en tarjetas para fácil visualización.

### Catálogos y Maestros
Gestión centralizada de tablas auxiliares del sistema:
- **Ciudades**: Administración de ubicaciones geográficas.
- **Tipos de Cuenta**: Configuración de productos bancarios.
- **Tipos de Documento**: Gestión de identificaciones permitidas.
- **Tipos de Movimiento**: Clasificación de transacciones.
- **Tipos de Sucursal**: Categorización de oficinas.

### Gestión de Titulares
- Asociación de múltiples titulares a una cuenta.
- Consulta de relaciones titular-cuenta.

## Tecnologías Utilizadas

- **.NET 9.0**: Framework de desarrollo.
- **Blazor WebAssembly**: Arquitectura de aplicación de página única (SPA).
- **Bootstrap 5**: Diseño responsivo y componentes de interfaz (Modales, Tarjetas, Tablas).
- **HttpClient**: Comunicación con la API REST.

## Requisitos Previos

- .NET 9 SDK o superior.
- Navegador web moderno (Chrome, Firefox, Edge).
- API ByteBank en ejecución (por defecto en `http://localhost:8000`).

## Instalación y Ejecución

1.  **Clonar el repositorio**
    ```bash
    git clone https://github.com/cristiancalderon82192-hue/byte_bank_blazor.git
    cd byte_bank_blazor
    ```

2.  **Restaurar dependencias**
    ```bash
    dotnet restore
    ```

3.  **Configuración**
    Verifique la URL de la API en `Program.cs` si es diferente a `http://localhost:8000`.

4.  **Ejecutar la aplicación**
    ```bash
    dotnet run
    ```
    O para desarrollo con recarga automática:
    ```bash
    dotnet watch run
    ```

La aplicación estará disponible en: `http://localhost:5161`

## Estructura del Proyecto

- **Pages**: Contiene los componentes de página (vistas) de la aplicación.
- **Models**: Definiciones de clases y DTOs para el intercambio de datos.
- **Services**: Capa de abstracción para la comunicación HTTP con la API.
- **Shared**: Componentes reutilizables y diseño principal (Layout).
- **wwwroot**: Archivos estáticos (CSS, imágenes, iconos).

## Autores

- **Cristian Arboleda** 