namespace ByteBank.Models
{
    public class TipoCuenta
    {
        public int IdTipoCuenta { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal? Sobregiro { get; set; }
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