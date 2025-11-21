using System.Net.Http.Json;
using ByteBank.Models;
using System.Text.Json;

namespace ByteBank.Services
{
    public class TitularService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBasePath = "/api/titulares";

        public TitularService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cuentahabiente>?> GetTitularesByCuentaAsync(int idCuenta)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<TitularesResponse>($"{ApiBasePath}/cuenta/{idCuenta}");
                return response?.Titulares;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener titulares: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Cuenta>?> GetCuentasByCuentahabienteAsync(int idCuentahabiente)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CuentasResponse>($"{ApiBasePath}/cuentahabiente/{idCuentahabiente}");
                return response?.Cuentas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cuentas del titular: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AsociarTitularAsync(int idCuenta, int idCuentahabiente)
        {
            try
            {
                var data = new { IdCuenta = idCuenta, IdCuentahabiente = idCuentahabiente };
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/", data);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al asociar titular: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RemoverTitularAsync(int idCuenta, int idCuentahabiente)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBasePath}/{idCuenta}/{idCuentahabiente}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al remover titular: {ex.Message}");
                return false;
            }
        }

        // DTOs para la respuesta de la API
        private class TitularesResponse
        {
            public int IdCuenta { get; set; }
            public int TotalTitulares { get; set; }
            public List<Cuentahabiente> Titulares { get; set; } = new();
        }

        private class CuentasResponse
        {
            public int IdCuentahabiente { get; set; }
            public int TotalCuentas { get; set; }
            public List<Cuenta> Cuentas { get; set; } = new();
        }
    }
}