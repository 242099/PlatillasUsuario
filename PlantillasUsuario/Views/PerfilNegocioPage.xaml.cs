using PlantillasUsuario.Models;
using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class PerfilNegocioPage : ContentPage
{
    public PerfilNegocioPage()
    {
        InitializeComponent();
        CargarDatosNegocio();
    }

    private void CargarDatosNegocio()
    {
        var seleccionado = DatosSimulados.PaqueteSeleccionado;
        if (seleccionado == null) return;

        imgBanner.Source = seleccionado.Imagen;
        lblNombreNegocio.Text = seleccionado.Panaderia;
        lblCalificacion.Text = seleccionado.Calificacion;
        lblHoras.Text = seleccionado.Horario.Replace("Hoy ", "");
        lblDireccion.Text = seleccionado.Direccion;
        lblTiempoPlataforma.Text = seleccionado.TiempoPlataforma;
        lblPaquetesSalvados.Text = seleccionado.PaquetesSalvados;
        lblAcercaDe.Text = seleccionado.AcercaDe;

        // Filtra todos los paquetes que pertenecen a esta panadería
        var paquetesDeEsteNegocio = DatosSimulados.Paquetes
            .Where(p => p.Panaderia == seleccionado.Panaderia)
            .ToList();

        BindableLayout.SetItemsSource(listaPaquetesNegocio, paquetesDeEsteNegocio);
    }

    private async void OnRegresarTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnPaqueteNegocioTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is PaqueteSorpresa paquete)
        {
            DatosSimulados.PaqueteSeleccionado = paquete;
            await Shell.Current.GoToAsync(nameof(DetallePaquetePage));
        }
    }

    private async void OnInicioNavTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//PrincipalPage");
    }

    private async void OnPedidosNavTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MisPedidosPage");
    }

    private async void OnFavoritosNavTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//FavoritosPage");
    }
}