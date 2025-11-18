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
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "El nombre de la sucursal es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue, ErrorMessage = "Seleccione una ciudad válida")]
        public int IdCiudad { get; set; }

        [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue, ErrorMessage = "Seleccione un tipo de sucursal válido")]
        public int IdTipoSucursal { get; set; }

        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Horario { get; set; }
    }
}