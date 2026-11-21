using PlantillasUsuario.Models;
using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class PrincipalPage : ContentPage
{
    private readonly List<string> _secciones = new() { "Inicio", "Pedidos", "Favoritos" };

    public PrincipalPage()
    {
        InitializeComponent();
        carruselPrincipal.ItemsSource = _secciones;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (DatosSimulados.PestanaInicial != 0)
        {
            int destino = DatosSimulados.PestanaInicial;
            DatosSimulados.PestanaInicial = 0;
            carruselPrincipal.ScrollTo(destino, animate: false);
            ActualizarPestanaActiva(destino);
        }
    }

    private void OnCarruselPositionChanged(object sender, PositionChangedEventArgs e)
    {
        ActualizarPestanaActiva(e.CurrentPosition);
    }

    private void ActualizarPestanaActiva(int posicion)
    {
        var colorActivoFondo = Color.FromArgb("#FBECE6");
        var colorActivoTexto = Color.FromArgb("#B5522D");
        var colorInactivoTexto = Color.FromArgb("#111111");

        tabInicio.BackgroundColor = posicion == 0 ? colorActivoFondo : Colors.Transparent;
        lblTabInicio.TextColor = posicion == 0 ? colorActivoTexto : colorInactivoTexto;
        lblTabInicio.FontAttributes = posicion == 0 ? FontAttributes.Bold : FontAttributes.None;

        tabPedidos.BackgroundColor = posicion == 1 ? colorActivoFondo : Colors.Transparent;
        lblTabPedidos.TextColor = posicion == 1 ? colorActivoTexto : colorInactivoTexto;
        lblTabPedidos.FontAttributes = posicion == 1 ? FontAttributes.Bold : FontAttributes.None;

        tabFavoritos.BackgroundColor = posicion == 2 ? colorActivoFondo : Colors.Transparent;
        lblTabFavoritos.TextColor = posicion == 2 ? colorActivoTexto : colorInactivoTexto;
        lblTabFavoritos.FontAttributes = posicion == 2 ? FontAttributes.Bold : FontAttributes.None;
    }

    // Eventos de la Barra Inferior (Deslizan suavemente el carrusel)
    private void OnInicioTapped(object sender, TappedEventArgs e) => carruselPrincipal.ScrollTo(0, animate: true);
    private void OnPedidosTapped(object sender, TappedEventArgs e) => carruselPrincipal.ScrollTo(1, animate: true);
    private void OnFavoritosTapped(object sender, TappedEventArgs e) => carruselPrincipal.ScrollTo(2, animate: true);

    // Eventos dentro de Inicio
    private async void OnPerfilTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PerfilUsuarioPage));
    }

    private async void OnPanaderiaNombreTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is PaqueteSorpresa paquete)
        {
            DatosSimulados.PaqueteSeleccionado = paquete;
            await Shell.Current.GoToAsync(nameof(PerfilNegocioPage));
        }
    }

    private async void OnPaqueteTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is PaqueteSorpresa paquete)
        {
            DatosSimulados.PaqueteSeleccionado = paquete;
            await Shell.Current.GoToAsync(nameof(DetallePaquetePage));
        }
    }

    // Eventos dentro de Pedidos
    private async void OnPedidoTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is PedidoReservado pedido)
        {
            DatosSimulados.UltimoPedido = pedido;
            await Shell.Current.GoToAsync(nameof(ReservaConfirmadaPage));
        }
    }

    // Eventos dentro de Favoritos
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
            DatosSimulados.AlternarFavorito(paquete);
        }
    }
}