using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class PlayersPage : ContentPage
{
    public PlayersPage(PlayersViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}