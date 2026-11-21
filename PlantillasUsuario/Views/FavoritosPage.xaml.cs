using PlantillasUsuario.Models;
using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class FavoritosPage : ContentPage
{
    public FavoritosPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarFavoritos();
    }

    private void CargarFavoritos()
    {
        cvFavoritos.ItemsSource = DatosSimulados.Paquetes
            .Where(p => p.EsFavorito)
            .ToList();
    }

    private async void OnTarjetaFavoritoTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is PaqueteSorpresa paquete)
        {
            if (paquete.Disponibles <= 0)
            {
                await DisplayAlert("Paquete agotado",
                    $"Por el momento {paquete.Panaderia} no tiene paquetes disponibles.",
                    "Entendido");
                return;
            }

            DatosSimulados.PaqueteSeleccionado = paquete;
            await Shell.Current.GoToAsync(nameof(DetallePaquetePage));
        }
    }

    private void OnQuitarFavoritoTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is PaqueteSorpresa paquete)
        {
            paquete.EsFavorito = false;
            CargarFavoritos();
        }
    }

    private async void OnInicioTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//InicioPage", false);
    }

    private async void OnPedidosTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MisPedidosPage", false);
    }
}