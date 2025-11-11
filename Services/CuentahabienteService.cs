using System.Net.Http.Json;
using ByteBank.Models;

namespace ByteBank.Services
{
    public class CuentahabienteService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "http://localhost:8000/api/cuentahabientes";

        public CuentahabienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cuentahabiente>?> GetCuentahabientesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Cuentahabiente>>(ApiBaseUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cuentahabientes: {ex.Message}");
                return null;
            }
        }

        public async Task<Cuentahabiente?> GetCuentahabienteAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cuentahabiente>($"{ApiBaseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cuentahabiente {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<Cuentahabiente?> GetCuentahabienteByDocumentoAsync(string documento)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cuentahabiente>($"{ApiBaseUrl}/documento/{documento}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar documento {documento}: {ex.Message}");
                return null;
            }
        }

        public async Task<Cuentahabiente?> CreateCuentahabienteAsync(CuentahabienteCreate cuentahabiente)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiBaseUrl, cuentahabiente);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Cuentahabiente>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cuentahabiente: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteCuentahabienteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar cuentahabiente: {ex.Message}");
                return false;
            }
        }
    }
}