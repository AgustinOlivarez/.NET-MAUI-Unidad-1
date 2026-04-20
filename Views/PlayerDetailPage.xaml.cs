using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class PlayerDetailPage : ContentPage
{
    public PlayerDetailPage(PlayerDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}