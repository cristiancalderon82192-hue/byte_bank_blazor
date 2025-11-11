namespace ByteBank.Models
{
    public class Ciudad
    {
        public int IdCiudad { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class CiudadCreate
    {
        public string Nombre { get; set; } = string.Empty;
    }
}