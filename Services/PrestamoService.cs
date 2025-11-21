using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public async Task<(CalculoCuotaResponse? Result, string? Error)> CalcularCuotaAsync(CalculoCuota calculo)
        {
            try
            {
                // Enviar Seguro como cadena formateada (ej. "0.00") si el backend lo espera así
                var payload = new
                {
                    Valor = calculo.Valor,
                    Interes = calculo.Interes,
                    Plazo = calculo.Plazo,
                    Seguro = calculo.Seguro ?? 0m
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = null, NumberHandling = JsonNumberHandling.AllowReadingFromString };
                var json = JsonSerializer.Serialize(payload, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{ApiBasePath}/calcular-cuota", content);
                var responseJson = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error al calcular cuota: {response.StatusCode} - {responseJson}");
                    return (null, responseJson);
                }

                var dto = JsonSerializer.Deserialize<CalculoCuotaResponse>(responseJson, options);
                return (dto, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular cuota: {ex.Message}");
                return (null, ex.Message);
            }
        }

        // Nota: El endpoint /api/prestamos/{id}/cuotas no existe en la API
        // Se puede usar CalcularCuotaAsync para calcular cuotas antes de crear el préstamo

        public async Task<(Prestamo? Result, string? Error)> CreatePrestamoAsync(PrestamoCreate prestamo)
        {
            try
            {
                var payload = new
                {
                    IdCuenta = prestamo.IdCuenta,
                    Numero = prestamo.Numero,
                    Fecha = prestamo.Fecha.ToString("yyyy-MM-dd"),
                    Valor = prestamo.Valor,
                    Interes = prestamo.Interes,
                    Plazo = prestamo.Plazo,
                    Seguro = prestamo.Seguro ?? 0m,
                    Cuota = prestamo.Cuota
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = null, NumberHandling = JsonNumberHandling.AllowReadingFromString };
                var json = JsonSerializer.Serialize(payload, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{ApiBasePath}/", content);
                var responseJson = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error al crear préstamo: {response.StatusCode} - {responseJson}");
                    return (null, responseJson);
                }

                var dto = JsonSerializer.Deserialize<Prestamo>(responseJson, options);
                return (dto, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear préstamo: {ex.Message}");
                return (null, ex.Message);
            }
        }

        public async Task<(Prestamo? Result, string? Error)> UpdatePrestamoAsync(int id, PrestamoCreate prestamo)
        {
            try
            {
                // El endpoint PUT espera solamente ciertos campos: Interes, Plazo, Seguro, Cuota
                var payload = new
                {
                    Interes = prestamo.Interes,
                    Plazo = prestamo.Plazo,
                    Seguro = prestamo.Seguro ?? 0m,
                    Cuota = prestamo.Cuota
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = null, NumberHandling = JsonNumberHandling.AllowReadingFromString };
                var json = JsonSerializer.Serialize(payload, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{ApiBasePath}/{id}", content);
                var responseJson = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error al actualizar préstamo: {response.StatusCode} - {responseJson}");
                    return (null, responseJson);
                }

                var dto = JsonSerializer.Deserialize<Prestamo>(responseJson, options);
                return (dto, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar préstamo: {ex.Message}");
                return (null, ex.Message);
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