using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class PerfilUsuarioPage : ContentPage
{
    public PerfilUsuarioPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarPerfil();
    }

    private void CargarPerfil()
    {
        if (DatosSimulados.UsuarioActual != null)
        {
            lblNombreUsuario.Text = DatosSimulados.UsuarioActual.Nombre;
            lblCorreoUsuario.Text = DatosSimulados.UsuarioActual.Correo;
        }

        // Si ya hizo pedidos en la sesión, actualiza los contadores; si no, mantiene 2 y $80 de muestra
        int pedidosSesion = DatosSimulados.Pedidos.Count;
        if (pedidosSesion > 0)
        {
            lblTotalPaquetes.Text = (2 + pedidosSesion).ToString();
            lblTotalAhorrado.Text = $"${80 + (pedidosSesion * 30)}";
        }
    }

    private async void OnMetodosPagoTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(GestionTarjetasPage));
    }

    private async void OnInicioTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//InicioPage");
    }

    private async void OnPedidosTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MisPedidosPage");
    }

    private async void OnFavoritosTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//FavoritosPage");
    }
}