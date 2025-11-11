using System.Net.Http.Json;
using ByteBank.Models;

namespace ByteBank.Services
{
    public class MovimientoService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "http://localhost:8000/api/movimientos";

        public MovimientoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener movimientos por cuenta
        public async Task<List<Movimiento>?> GetMovimientosByCuentaAsync(int idCuenta)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Movimiento>>($"{ApiBaseUrl}/cuenta/{idCuenta}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener movimientos: {ex.Message}");
                return null;
            }
        }

        // Realizar depósito
        public async Task<Movimiento?> RealizarDepositoAsync(DepositoCreate deposito)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBaseUrl}/deposito", deposito);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Movimiento>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar depósito: {ex.Message}");
                return null;
            }
        }

        // Realizar retiro
        public async Task<Movimiento?> RealizarRetiroAsync(RetiroCreate retiro)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBaseUrl}/retiro", retiro);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Movimiento>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar retiro: {ex.Message}");
                throw; // Re-lanzar para mostrar error al usuario
            }
        }

        // Realizar transferencia
        public async Task<object?> RealizarTransferenciaAsync(TransferenciaCreate transferencia)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBaseUrl}/transferencia", transferencia);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<object>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar transferencia: {ex.Message}");
                throw;
            }
        }
    }
}