namespace ByteBank.Models
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdCiudad { get; set; }
        public int IdTipoSucursal { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Horario { get; set; }
    }

    public class SucursalCreate
    {
        public string Nombre { get; set; } = string.Empty;
        public int IdCiudad { get; set; }
        public int IdTipoSucursal { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Horario { get; set; }
    }
}