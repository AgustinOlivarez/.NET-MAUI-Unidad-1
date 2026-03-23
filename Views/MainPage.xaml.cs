using MauiApp1.ViewModels;
namespace MauiApp1.Views
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            //Conexión con el ViewModel
            BindingContext = new ProfileViewModel();
        }
    }
}
