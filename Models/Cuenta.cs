namespace ByteBank.Models
{
    public class Cuenta
    {
        public int IdCuenta { get; set; }
        public string Numero { get; set; } = string.Empty;
        public DateTime FechaApertura { get; set; }
        public int IdTipoCuenta { get; set; }
        public int IdSucursal { get; set; }
        public decimal Saldo { get; set; }
        public decimal? Sobregiro { get; set; }
        public bool? GranMovimiento { get; set; }
        public bool? SobregiroNoAutorizado { get; set; }
    }

    public class CuentaCreate
    {
        public string Numero { get; set; } = string.Empty;
        public DateTime FechaApertura { get; set; }
        public int IdTipoCuenta { get; set; }
        public int IdSucursal { get; set; }
        public decimal Saldo { get; set; } = 0;
        public decimal? Sobregiro { get; set; } = 0;
    }

    public class SaldoResponse
    {
        public int IdCuenta { get; set; }
        public string Numero { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public decimal? Sobregiro { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}