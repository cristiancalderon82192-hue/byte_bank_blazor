using System.Globalization;

namespace ByteBank.Models
{
    public class TipoCuenta
    {
        public int IdTipoCuenta { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("TipoCuenta")]
        public string Nombre { get; set; } = string.Empty;

        [System.Text.Json.Serialization.JsonIgnore]
        public decimal? Sobregiro { get; set; }

        // El API a veces devuelve el sobregiro como cadena ("0.00").
        // Esta propiedad auxiliar permite parsear esa cadena al deserializar.
        // Usamos la propiedad alias con JsonPropertyName("Sobregiro") y
        // marcamos la propiedad decimal con JsonIgnore para evitar colisiones.
        [System.Text.Json.Serialization.JsonPropertyName("Sobregiro")]
        public string? SobregiroAlias
        {
            get => Sobregiro?.ToString("F2", CultureInfo.InvariantCulture);
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d))
                        Sobregiro = d;
                }
            }
        }
    }

    public class TipoDocumento
    {
        public int IdTipoDocumento { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Sigla { get; set; }
        // Alias para aceptar JSON que use la clave "TipoDocumento" en lugar de "Nombre"
        [System.Text.Json.Serialization.JsonPropertyName("TipoDocumento")]
        public string? TipoDocumentoAlias
        {
            get => Nombre;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    Nombre = value!;
            }
        }
    }

    public class TipoMovimiento
    {
        public int IdTipoMovimiento { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("TipoMovimiento")]
        public string Nombre { get; set; } = string.Empty;
    }

    public class TipoSucursal
    {
        public int IdTipoSucursal { get; set; }
        public string Nombre { get; set; } = string.Empty;
        // Alias para aceptar JSON que use la clave "TipoSucursal" en lugar de "Nombre"
        [System.Text.Json.Serialization.JsonPropertyName("TipoSucursal")]
        public string? TipoSucursalAlias
        {
            get => Nombre;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    Nombre = value!;
            }
        }
    }
}