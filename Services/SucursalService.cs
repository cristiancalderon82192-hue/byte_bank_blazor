using System.Net.Http.Json;
using ByteBank.Models;

namespace ByteBank.Services
{
    public class SucursalService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBasePath = "/api/sucursales";

        public SucursalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Sucursal>?> GetSucursalesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Sucursal>>($"{ApiBasePath}/");
            }
            catch (Exception ex)
            {
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
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/", sucursal);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Sucursal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear sucursal: {ex.Message}");
                return null;
            }
        }

        public async Task<Sucursal?> UpdateSucursalAsync(int id, SucursalCreate sucursal)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiBasePath}/{id}", sucursal);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Sucursal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar sucursal: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteSucursalAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBasePath}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar sucursal: {ex.Message}");
                return false;
            }
        }
    }
}