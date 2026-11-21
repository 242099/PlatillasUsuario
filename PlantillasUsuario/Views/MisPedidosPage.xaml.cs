using PlantillasUsuario.Models;
using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class MisPedidosPage : ContentPage
{
    public MisPedidosPage()
    {
        InitializeComponent();
        cvPedidos.ItemsSource = DatosSimulados.Pedidos;
    }

    private async void OnPedidoTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is PedidoReservado pedido)
        {
            DatosSimulados.UltimoPedido = pedido;
            await Shell.Current.GoToAsync(nameof(ReservaConfirmadaPage));
        }
    }

    private async void OnInicioTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//InicioPage", false);
    }

    private async void OnFavoritosTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//FavoritosPage", false);
    }
}