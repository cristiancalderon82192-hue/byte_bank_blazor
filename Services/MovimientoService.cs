using System.Net.Http.Json;
using ByteBank.Models;

namespace ByteBank.Services
{
    public class MovimientoService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBasePath = "/api/movimientos";

        public MovimientoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todos los movimientos
        public async Task<List<Movimiento>?> GetMovimientosAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Movimiento>>($"{ApiBasePath}/");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener movimientos: {ex.Message}");
                return null;
            }
        }

        // Obtener movimiento por ID
        public async Task<Movimiento?> GetMovimientoAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Movimiento>($"{ApiBasePath}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener movimiento {id}: {ex.Message}");
                return null;
            }
        }

        // Obtener movimientos por cuenta
        public async Task<List<Movimiento>?> GetMovimientosByCuentaAsync(int idCuenta)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Movimiento>>($"{ApiBasePath}/cuenta/{idCuenta}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener movimientos: {ex.Message}");
                return null;
            }
        }

        // Obtener movimientos por rango de fechas
        public async Task<List<Movimiento>?> GetMovimientosByFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd");
                var fechaFinStr = fechaFin.ToString("yyyy-MM-dd");
                return await _httpClient.GetFromJsonAsync<List<Movimiento>>($"{ApiBasePath}/fecha/{fechaInicioStr}/{fechaFinStr}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener movimientos por fecha: {ex.Message}");
                return null;
            }
        }

        // Realizar depósito
        public async Task<Movimiento?> RealizarDepositoAsync(DepositoCreate deposito)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/deposito", deposito);
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
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/retiro", retiro);
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
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/transferencia", transferencia);
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