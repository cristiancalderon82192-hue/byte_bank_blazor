using System.Net.Http.Json;
using ByteBank.Models;

namespace ByteBank.Services
{
    public class PrestamoService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "http://localhost:8000/api/prestamos";

        public PrestamoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Prestamo>?> GetPrestamosAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Prestamo>>(ApiBaseUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener préstamos: {ex.Message}");
                return null;
            }
        }

        public async Task<Prestamo?> GetPrestamoAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Prestamo>($"{ApiBaseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener préstamo {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Prestamo>?> GetPrestamosByCuentaAsync(int idCuenta)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Prestamo>>($"{ApiBaseUrl}/cuenta/{idCuenta}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener préstamos de cuenta: {ex.Message}");
                return null;
            }
        }

        public async Task<CalculoCuotaResponse?> CalcularCuotaAsync(CalculoCuota calculo)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBaseUrl}/calcular-cuota", calculo);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CalculoCuotaResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular cuota: {ex.Message}");
                return null;
            }
        }

        public async Task<Prestamo?> CreatePrestamoAsync(PrestamoCreate prestamo)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiBaseUrl, prestamo);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Prestamo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear préstamo: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeletePrestamoAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar préstamo: {ex.Message}");
                return false;
            }
        }
    }
}