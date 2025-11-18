namespace ByteBank.Models
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("Sucursal")]
        public string Nombre { get; set; } = string.Empty;
        public int IdCiudad { get; set; }
        public int IdTipoSucursal { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Horario { get; set; }
    }

    public class SucursalCreate
    {
        [System.Text.Json.Serialization.JsonPropertyName("Sucursal")]
        public string Nombre { get; set; } = string.Empty;
        public int IdCiudad { get; set; }
        public int IdTipoSucursal { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Horario { get; set; }
    }
}