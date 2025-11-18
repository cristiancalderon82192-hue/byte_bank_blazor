namespace ByteBank.Models
{
    public class Cuentahabiente
    {
        public int IdCuentahabiente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdTipoDocumento { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int IdCiudad { get; set; }
        
        // Campos relacionados desde el backend
        public string? NombreCiudad { get; set; }
        public string? TipoDocumentoNombre { get; set; }
    }

    public class CuentahabienteCreate
    {
        public string Nombre { get; set; } = string.Empty;
        public int IdTipoDocumento { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int IdCiudad { get; set; }
        public string Clave { get; set; } = string.Empty;
    }

    public class CuentahabienteUpdate
    {
        public string? Nombre { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int? IdCiudad { get; set; }
        public string? Clave { get; set; }
    }

    // Clase auxiliar para el formulario
    public class CuentahabienteFormulario
    {
        public string Nombre { get; set; } = string.Empty;
        public string? TipoDocumentoSeleccionado { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? CiudadSeleccionada { get; set; }
        public string Clave { get; set; } = string.Empty;
    }
}