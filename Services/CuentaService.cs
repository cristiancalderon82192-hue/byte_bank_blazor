using System.Net.Http.Json;
using ByteBank.Models;

namespace ByteBank.Services
{
    public class CuentaService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "http://localhost:8000/api/cuentas";

        public CuentaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todas las cuentas
        public async Task<List<Cuenta>?> GetCuentasAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Cuenta>>(ApiBaseUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cuentas: {ex.Message}");
                return null;
            }
        }

        // Obtener cuenta por ID
        public async Task<Cuenta?> GetCuentaAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cuenta>($"{ApiBaseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cuenta {id}: {ex.Message}");
                return null;
            }
        }

        // Obtener cuenta por número
        public async Task<Cuenta?> GetCuentaByNumeroAsync(string numero)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cuenta>($"{ApiBaseUrl}/numero/{numero}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar cuenta {numero}: {ex.Message}");
                return null;
            }
        }

        // Consultar saldo
        public async Task<SaldoResponse?> GetSaldoAsync(int idCuenta)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<SaldoResponse>($"{ApiBaseUrl}/{idCuenta}/saldo");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener saldo: {ex.Message}");
                return null;
            }
        }

        // Crear nueva cuenta
        public async Task<Cuenta?> CreateCuentaAsync(CuentaCreate cuenta)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiBaseUrl, cuenta);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Cuenta>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cuenta: {ex.Message}");
                return null;
            }
        }

        // Eliminar cuenta
        public async Task<bool> DeleteCuentaAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar cuenta: {ex.Message}");
                return false;
            }
        }
    }
}