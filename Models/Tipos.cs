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
    }
}