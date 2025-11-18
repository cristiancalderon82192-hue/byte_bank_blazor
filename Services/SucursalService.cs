using System.Net.Http.Json;
using System.Text.Json;
using ByteBank.Models;

namespace ByteBank.Services
{
    public class SucursalService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBasePath = "/api/sucursales";
        public string? LastError { get; private set; }

        public SucursalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Sucursal>?> GetSucursalesAsync()
        {
            try
            {
                LastError = null;
                return await _httpClient.GetFromJsonAsync<List<Sucursal>>($"{ApiBasePath}/");
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"Error al obtener sucursales: {ex.Message}");
                return null;
            }
        }

        public async Task<Sucursal?> GetSucursalAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Sucursal>($"{ApiBasePath}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener sucursal {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Sucursal>?> GetSucursalesByCiudadAsync(int idCiudad)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Sucursal>>($"{ApiBasePath}/ciudad/{idCiudad}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener sucursales por ciudad: {ex.Message}");
                return null;
            }
        }

        public async Task<Sucursal?> CreateSucursalAsync(SucursalCreate sucursal)
        {
            try
            {
                LastError = null;
                var options = new JsonSerializerOptions { PropertyNamingPolicy = null };
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/", sucursal, options);
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    LastError = content;
                    Console.WriteLine($"Error al crear sucursal: {content}");
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<Sucursal>();
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"Error al crear sucursal: {ex.Message}");
                return null;
            }
        }

        public async Task<Sucursal?> UpdateSucursalAsync(int id, SucursalCreate sucursal)
        {
            try
            {
                LastError = null;
                var options = new JsonSerializerOptions { PropertyNamingPolicy = null };
                var response = await _httpClient.PutAsJsonAsync($"{ApiBasePath}/{id}", sucursal, options);
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    LastError = content;
                    Console.WriteLine($"Error al actualizar sucursal: {content}");
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<Sucursal>();
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"Error al actualizar sucursal: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteSucursalAsync(int id)
        {
            try
            {
                LastError = null;
                var response = await _httpClient.DeleteAsync($"{ApiBasePath}/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LastError = content;
                    Console.WriteLine($"Error al eliminar sucursal: {content}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"Error al eliminar sucursal: {ex.Message}");
                return false;
            }
        }
    }
}