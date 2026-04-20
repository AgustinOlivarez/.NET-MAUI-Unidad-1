using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Models;

namespace MauiApp1.ViewModels
{
    [QueryProperty(nameof(Player), "SelectedPlayer")]
    public partial class PlayerDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Player _player;
    }
}