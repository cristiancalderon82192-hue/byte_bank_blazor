using System.Net.Http.Json;

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

        public async Task<object?> GetTitularesByCuentaAsync(int idCuenta)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<object>($"{ApiBasePath}/cuenta/{idCuenta}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener titulares: {ex.Message}");
                return null;
            }
        }

        public async Task<object?> GetCuentasByCuentahabienteAsync(int idCuentahabiente)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<object>($"{ApiBasePath}/cuentahabiente/{idCuentahabiente}");
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
    }
}