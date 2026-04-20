using System.Text.Json;
using MauiApp1.Models;

namespace MauiApp1.Services
{
    public class PlayerService
    {
        private readonly HttpClient _httpClient;

        public PlayerService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            try
            {
                // Esta es una URL de API pública de marcador de posición.
                // En un escenario real apuntarías a una API REST válida.
                // Simularemos el comportamiento interno si falla, o simplemente lanzaremos la excepción para que sea manejada por el ViewModel.
                var response = await _httpClient.GetAsync("https://api.example.com/players");
                
                // Lanza HttpRequestException con su propiedad StatusCode si está fuera de 200-299
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var players = JsonSerializer.Deserialize<List<Player>>(json);
                return players ?? new List<Player>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        // Método simulado en caso de ser necesario ya que no se proporcionó una API pública
        public async Task<List<Player>> GetMockPlayersAsync()
        {
            await Task.Delay(1000); // Simular retraso de red para que no cargue instantáneamente
            return new List<Player>
            {
                new Player { Id = "1", Nombre = "Lionel Messi", Posicion = "Delantero", Equipo = "Inter Miami" },
                new Player { Id = "2", Nombre = "Cristiano Ronaldo", Posicion = "Delantero", Equipo = "Al Nassr" },
                new Player { Id = "3", Nombre = "Emiliano Martinez", Posicion = "Arquero", Equipo = "Aston Villa" },
                new Player { Id = "4", Nombre = "Kevin De Bruyne", Posicion = "Mediocampista", Equipo = "Manchester City" },
                new Player { Id = "5", Nombre = "Virgil van Dijk", Posicion = "Defensor", Equipo = "Liverpool" }
            };
        }
    }
}