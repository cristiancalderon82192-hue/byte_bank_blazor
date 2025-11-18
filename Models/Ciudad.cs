namespace ByteBank.Models
{
    public class Ciudad
    {
        public int IdCiudad { get; set; }
        public string Nombre { get; set; } = string.Empty;

        // Alias para aceptar JSON que use la clave "Ciudad" en lugar de "Nombre"
        [System.Text.Json.Serialization.JsonPropertyName("Ciudad")]
        public string? CiudadAlias
        {
            get => Nombre;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    Nombre = value!;
            }
        }
    }

    public class CiudadCreate
    {
        public string Nombre { get; set; } = string.Empty;
    }
}