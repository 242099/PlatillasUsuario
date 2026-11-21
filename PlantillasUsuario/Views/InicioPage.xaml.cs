using PlantillasUsuario.Models;
using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class InicioPage : ContentPage
{
    public InicioPage()
    {
        InitializeComponent();
        cvPaquetes.ItemsSource = DatosSimulados.Paquetes;
    }

    private async void OnPaqueteTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is PaqueteSorpresa paquete)
        {
            DatosSimulados.PaqueteSeleccionado = paquete;
            await Shell.Current.GoToAsync(nameof(DetallePaquetePage));
        }
    }

    private async void OnPanaderiaNombreTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is PaqueteSorpresa paquete)
        {
            DatosSimulados.PaqueteSeleccionado = paquete;
            await Shell.Current.GoToAsync(nameof(PerfilNegocioPage));
        }
    }

    private async void OnPerfilTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PerfilUsuarioPage));
    }

    private async void OnPedidosTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MisPedidosPage", false);
    }

    private async void OnFavoritosTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//FavoritosPage", false);
    }
}