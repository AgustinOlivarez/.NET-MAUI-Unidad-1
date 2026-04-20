using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;

namespace MauiApp1.ViewModels
{
    public partial class PlayersViewModel : ObservableObject
    {
        private readonly PlayerService _playerService;
        
        [ObservableProperty]
        private bool _isBusy;
        
        [ObservableProperty]
        private string _statusMessage;
        
        public ObservableCollection<Player> Players { get; } = new ObservableCollection<Player>();

        public PlayersViewModel(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [RelayCommand]
        private async Task LoadPlayersAsync()
        {
            if (_isBusy) return;

            IsBusy = true;
            StatusMessage = "Cargando jugadores...";
            Players.Clear();

            try
            {
                // En una aplicación real cambiamos esto a _playerService.GetPlayersAsync() 
                // pero dado que la URL es de prueba usamos el mock
                var players = await _playerService.GetMockPlayersAsync();
                
                foreach (var player in players)
                {
                    Players.Add(player);
                }
                
                StatusMessage = string.Empty;
            }
            catch (HttpRequestException httpEx)
            {
                if (httpEx.StatusCode.HasValue)
                {
                    int statusCode = (int)httpEx.StatusCode.Value;
                    if (statusCode >= 400 && statusCode < 500)
                        StatusMessage = $"Error del cliente ({statusCode}): Verifique la solicitud (EJ: 400/404).";
                    else if (statusCode >= 500)
                        StatusMessage = $"Error del servidor ({statusCode}): Hubo un problema (EJ: 500), intente más tarde.";
                    else
                        StatusMessage = $"Error HTTP ({statusCode}): {httpEx.Message}";
                }
                else
                {
                    StatusMessage = "Problema de conexión: No se pudo conectar al servidor. Compruebe su internet.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error inesperado de datos u otros: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task SelectPlayerAsync(Player player)
        {
            if (player == null) return;
            
            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedPlayer", player }
            };
            
            await Shell.Current.GoToAsync(nameof(PlayerDetailPage), navigationParameter);
        }
    }
}