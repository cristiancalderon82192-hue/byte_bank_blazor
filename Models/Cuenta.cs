using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ByteBank.Models
{
    public class Cuenta
    {
        [JsonPropertyName("IdCuenta")]
        public int IdCuenta { get; set; }

        [JsonPropertyName("Numero")]
        public string Numero { get; set; } = string.Empty;

        [JsonPropertyName("FechaApertura")]
        public DateOnly FechaApertura { get; set; }

        [JsonPropertyName("IdTipoCuenta")]
        public int IdTipoCuenta { get; set; }

        [JsonPropertyName("IdSucursal")]
        public int? IdSucursal { get; set; }

        [JsonPropertyName("Saldo")]
        public decimal Saldo { get; set; }

        [JsonPropertyName("Sobregiro")]
        public decimal? Sobregiro { get; set; }

        [JsonPropertyName("GranMovimiento")]
        public bool? GranMovimiento { get; set; }

        [JsonPropertyName("SobregiroNoAutorizado")]
        public bool? SobregiroNoAutorizado { get; set; }
    }

    public class CuentaCreate
    {
        [Required(ErrorMessage = "El número de cuenta es obligatorio")]
        [JsonPropertyName("Numero")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de apertura es obligatoria")]
        [JsonPropertyName("FechaApertura")]
        public DateOnly FechaApertura { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de cuenta")]
        [JsonPropertyName("IdTipoCuenta")]
        public int IdTipoCuenta { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una sucursal")]
        [JsonPropertyName("IdSucursal")]
        public int IdSucursal { get; set; }

        [JsonPropertyName("Saldo")]
        public decimal Saldo { get; set; } = 0;

        [JsonPropertyName("Sobregiro")]
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