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
}