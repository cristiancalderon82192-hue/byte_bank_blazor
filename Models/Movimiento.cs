namespace ByteBank.Models
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public int IdSucursal { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public int IdTipoMovimiento { get; set; }
        public string? Descripcion { get; set; }
    }

    public class DepositoCreate
    {
        public int IdCuenta { get; set; }
        public int IdSucursal { get; set; }
        public decimal Valor { get; set; }
        public string? Descripcion { get; set; }
    }

    public class RetiroCreate
    {
        public int IdCuenta { get; set; }
        public int IdSucursal { get; set; }
        public decimal Valor { get; set; }
        public string? Descripcion { get; set; }
    }

    public class TransferenciaCreate
    {
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public int IdSucursal { get; set; }
        public decimal Valor { get; set; }
        public string? Descripcion { get; set; }
    }
}