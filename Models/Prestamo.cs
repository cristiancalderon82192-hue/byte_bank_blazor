namespace ByteBank.Models
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public int IdCuenta { get; set; }
        public string Numero { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Interes { get; set; }
        public int Plazo { get; set; }
        public decimal? Seguro { get; set; }
        public decimal Cuota { get; set; }
    }

    public class PrestamoCreate
    {
        public int IdCuenta { get; set; }
        public string Numero { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Interes { get; set; }
        public int Plazo { get; set; }
        public decimal? Seguro { get; set; }
    }

    public class CalculoCuota
    {
        public decimal Valor { get; set; }
        public decimal Interes { get; set; }
        public int Plazo { get; set; }
        public decimal? Seguro { get; set; }
    }

    public class CalculoCuotaResponse
    {
        public decimal CuotaMensual { get; set; }
        public decimal TotalAPagar { get; set; }
        public decimal TotalIntereses { get; set; }
    }
}