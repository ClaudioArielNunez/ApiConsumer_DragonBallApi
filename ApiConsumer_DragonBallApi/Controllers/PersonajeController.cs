using ApiConsumer_DragonBallApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
namespace ApiConsumer_DragonBallApi.Controllers
{
    public class PersonajeController : Controller
    {
        private readonly HttpClient _httpClient;

        public PersonajeController(IHttpClientFactory httpClientFactory)
        {
            // Configura el HttpClientHandler
            var handler = new HttpClientHandler
            {
                // Desactiva la validación del certificado (Solo para desarrollo)
                ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
            };

            // Crea el HttpClient con el handler configurado
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://dragonball-api.com/api")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/characters/1");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var personaje = JsonConvert.DeserializeObject<Personaje>(content);
                    return View(personaje);
                }

                return NotFound();
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error en la solicitud: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error inesperado: {ex.Message}");
            }
        }
    }
}
