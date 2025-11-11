using System.Net.Http.Json;
using ByteBank.Models;

namespace ByteBank.Services
{
    public class CatalogoService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "http://localhost:8000/api";

        public CatalogoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Ciudades
        public async Task<List<Ciudad>?> GetCiudadesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Ciudad>>($"{ApiBaseUrl}/ciudades");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener ciudades: {ex.Message}");
                return null;
            }
        }

        // Tipos de Cuenta
        public async Task<List<TipoCuenta>?> GetTiposCuentaAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<TipoCuenta>>($"{ApiBaseUrl}/tipos/cuenta");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tipos de cuenta: {ex.Message}");
                return null;
            }
        }

        // Tipos de Documento
        public async Task<List<TipoDocumento>?> GetTiposDocumentoAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<TipoDocumento>>($"{ApiBaseUrl}/tipos/documento");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tipos de documento: {ex.Message}");
                return null;
            }
        }

        // Tipos de Movimiento
        public async Task<List<TipoMovimiento>?> GetTiposMovimientoAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<TipoMovimiento>>($"{ApiBaseUrl}/tipos/movimiento");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tipos de movimiento: {ex.Message}");
                return null;
            }
        }

        // Tipos de Sucursal
        public async Task<List<TipoSucursal>?> GetTiposSucursalAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<TipoSucursal>>($"{ApiBaseUrl}/tipos/sucursal");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tipos de sucursal: {ex.Message}");
                return null;
            }
        }

        // Sucursales
        public async Task<List<Sucursal>?> GetSucursalesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Sucursal>>($"{ApiBaseUrl}/sucursales");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener sucursales: {ex.Message}");
                return null;
            }
        }
    }
}