using System.Net.Http.Json;
using ByteBank.Models;

namespace ByteBank.Services
{
    public class PrestamoService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBasePath = "/api/prestamos";

        public PrestamoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Prestamo>?> GetPrestamosAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Prestamo>>($"{ApiBasePath}/");
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
                return await _httpClient.GetFromJsonAsync<Prestamo>($"{ApiBasePath}/{id}");
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
                return await _httpClient.GetFromJsonAsync<List<Prestamo>>($"{ApiBasePath}/cuenta/{idCuenta}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener préstamos de cuenta: {ex.Message}");
                return null;
            }
        }

        public async Task<Prestamo?> GetPrestamoByNumeroAsync(string numero)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Prestamo>($"{ApiBasePath}/numero/{numero}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener préstamo por número: {ex.Message}");
                return null;
            }
        }

        public async Task<CalculoCuotaResponse?> CalcularCuotaAsync(CalculoCuota calculo)
        {
            try
            {
                // Nota: Este endpoint puede no estar en la documentación oficial
                // Si no existe, se puede calcular en el frontend o agregar al backend
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/calcular-cuota", calculo);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CalculoCuotaResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular cuota: {ex.Message}");
                return null;
            }
        }

        // Nota: El endpoint /api/prestamos/{id}/cuotas no existe en la API
        // Se puede usar CalcularCuotaAsync para calcular cuotas antes de crear el préstamo

        public async Task<Prestamo?> CreatePrestamoAsync(PrestamoCreate prestamo)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/", prestamo);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Prestamo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear préstamo: {ex.Message}");
                return null;
            }
        }

        public async Task<Prestamo?> UpdatePrestamoAsync(int id, PrestamoCreate prestamo)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiBasePath}/{id}", prestamo);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Prestamo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar préstamo: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeletePrestamoAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBasePath}/{id}");
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