using System.Net.Http.Json;
using ByteBank.Models;

namespace ByteBank.Services
{
    public class CatalogoService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBasePath = "/api";

        public CatalogoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Ciudades
        public async Task<List<Ciudad>?> GetCiudadesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Ciudad>>($"{ApiBasePath}/ciudades");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener ciudades: {ex.Message}");
                return null;
            }
        }

        public async Task<Ciudad?> CreateCiudadAsync(CiudadCreate ciudad)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/ciudades", ciudad);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Ciudad>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear ciudad: {ex.Message}");
                return null;
            }
        }

        // Tipos de Cuenta
        public async Task<List<TipoCuenta>?> GetTiposCuentaAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiBasePath}/tipos/cuenta");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error al obtener tipos de cuenta: status {response.StatusCode}");
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(content))
                    return new List<TipoCuenta>();

                var options = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Intentar deserializar como arreglo
                try
                {
                    var lista = System.Text.Json.JsonSerializer.Deserialize<List<TipoCuenta>>(content, options);
                    if (lista != null)
                        return lista;

                    // Si no es arreglo, intentar como objeto único
                    var single = System.Text.Json.JsonSerializer.Deserialize<TipoCuenta>(content, options);
                    if (single != null)
                        return new List<TipoCuenta> { single };
                }
                catch (System.Text.Json.JsonException je)
                {
                    Console.WriteLine($"Error JSON al obtener tipos de cuenta: {je.Message}");
                    return null;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tipos de cuenta: {ex.Message}");
                return null;
            }
        }

        public async Task<TipoCuenta?> CreateTipoCuentaAsync(TipoCuentaCreate tipoCuenta)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/tipos/cuenta", tipoCuenta);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TipoCuenta>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear tipo de cuenta: {ex.Message}");
                return null;
            }
        }

        public async Task<TipoCuenta?> UpdateTipoCuentaAsync(int id, TipoCuentaCreate tipoCuenta)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiBasePath}/tipos/cuenta/{id}", tipoCuenta);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TipoCuenta>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar tipo de cuenta: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteTipoCuentaAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBasePath}/tipos/cuenta/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar tipo de cuenta: {ex.Message}");
                return false;
            }
        }

        // Tipos de Documento
        public async Task<List<TipoDocumento>?> GetTiposDocumentoAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<TipoDocumento>>($"{ApiBasePath}/tipos/documento");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tipos de documento: {ex.Message}");
                return null;
            }
        }

        public async Task<TipoDocumento?> CreateTipoDocumentoAsync(TipoDocumentoCreate tipoDocumento)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/tipos/documento", tipoDocumento);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TipoDocumento>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear tipo de documento: {ex.Message}");
                return null;
            }
        }

        public async Task<TipoDocumento?> UpdateTipoDocumentoAsync(int id, TipoDocumentoCreate tipoDocumento)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiBasePath}/tipos/documento/{id}", tipoDocumento);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TipoDocumento>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar tipo de documento: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteTipoDocumentoAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBasePath}/tipos/documento/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar tipo de documento: {ex.Message}");
                return false;
            }
        }

        // Tipos de Movimiento
        public async Task<List<TipoMovimiento>?> GetTiposMovimientoAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<TipoMovimiento>>($"{ApiBasePath}/tipos/movimiento");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tipos de movimiento: {ex.Message}");
                return null;
            }
        }

        public async Task<TipoMovimiento?> CreateTipoMovimientoAsync(TipoMovimientoCreate tipoMovimiento)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/tipos/movimiento", tipoMovimiento);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TipoMovimiento>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear tipo de movimiento: {ex.Message}");
                return null;
            }
        }

        public async Task<TipoMovimiento?> UpdateTipoMovimientoAsync(int id, TipoMovimientoCreate tipoMovimiento)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiBasePath}/tipos/movimiento/{id}", tipoMovimiento);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TipoMovimiento>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar tipo de movimiento: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteTipoMovimientoAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBasePath}/tipos/movimiento/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar tipo de movimiento: {ex.Message}");
                return false;
            }
        }

        // Tipos de Sucursal
        public async Task<List<TipoSucursal>?> GetTiposSucursalAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<TipoSucursal>>($"{ApiBasePath}/tipos/sucursal");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tipos de sucursal: {ex.Message}");
                return null;
            }
        }

        public async Task<TipoSucursal?> CreateTipoSucursalAsync(TipoSucursalCreate tipoSucursal)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiBasePath}/tipos/sucursal", tipoSucursal);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TipoSucursal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear tipo de sucursal: {ex.Message}");
                return null;
            }
        }

        public async Task<TipoSucursal?> UpdateTipoSucursalAsync(int id, TipoSucursalCreate tipoSucursal)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiBasePath}/tipos/sucursal/{id}", tipoSucursal);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TipoSucursal>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar tipo de sucursal: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteTipoSucursalAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBasePath}/tipos/sucursal/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar tipo de sucursal: {ex.Message}");
                return false;
            }
        }

        // Sucursales
        public async Task<List<Sucursal>?> GetSucursalesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Sucursal>>($"{ApiBasePath}/sucursales/");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener sucursales: {ex.Message}");
                return null;
            }
        }

        // Actualizar ciudad
        public async Task<Ciudad?> UpdateCiudadAsync(int id, CiudadCreate ciudad)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiBasePath}/ciudades/{id}", ciudad);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Ciudad>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar ciudad: {ex.Message}");
                return null;
            }
        }

        // Eliminar ciudad
        public async Task<bool> DeleteCiudadAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBasePath}/ciudades/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar ciudad: {ex.Message}");
                return false;
            }
        }
    }
}