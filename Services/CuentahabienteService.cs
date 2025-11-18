using System.Net.Http.Json;
using ByteBank.Models;
using System.Text.Json;

namespace ByteBank.Services
{
    public class CuentahabienteService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBasePath = "/api/cuentahabientes";
        // Enviar JSON con nombres de propiedad tal como están en los modelos (PascalCase)
        private static readonly JsonSerializerOptions PascalCaseSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null
        };

        public CuentahabienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cuentahabiente>?> GetCuentahabientesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Cuentahabiente>>($"{ApiBasePath}/");
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
                return await _httpClient.GetFromJsonAsync<Cuentahabiente>($"{ApiBasePath}/{id}");
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
                return await _httpClient.GetFromJsonAsync<Cuentahabiente>($"{ApiBasePath}/documento/{documento}");
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
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/", cuentahabiente, PascalCaseSerializerOptions);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Cuentahabiente>();
                }
                else
                {
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al crear cuentahabiente. Status: {(int)response.StatusCode} {response.ReasonPhrase}. Body: {body}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cuentahabiente: {ex.Message}");
                return null;
            }
        }

        public async Task<Cuentahabiente?> UpdateCuentahabienteAsync(int id, CuentahabienteCreate cuentahabiente)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiBasePath}/{id}", cuentahabiente, PascalCaseSerializerOptions);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Cuentahabiente>();
                }
                else
                {
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al actualizar cuentahabiente. Status: {(int)response.StatusCode} {response.ReasonPhrase}. Body: {body}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar cuentahabiente: {ex.Message}");
                return null;
            }
        }

        // Nota: Las cuentas del cliente se obtienen desde TitularService.GetCuentasByCuentahabienteAsync()

        public async Task<bool> DeleteCuentahabienteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBasePath}/{id}");
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