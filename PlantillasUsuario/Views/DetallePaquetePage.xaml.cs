using PlantillasUsuario.Models;
using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class DetallePaquetePage : ContentPage
{
    private PaqueteSorpresa? _paquete;

    public DetallePaquetePage()
    {
        InitializeComponent();
        CargarDetalle();
    }

    private void CargarDetalle()
    {
        _paquete = DatosSimulados.PaqueteSeleccionado;
        if (_paquete == null) return;

        imgPaquete.Source = _paquete.Imagen;
        lblNombrePaquete.Text = _paquete.NombrePaquete;
        lblPanaderia.Text = _paquete.Panaderia;
        lblPanaderiaUbicacion.Text = _paquete.Panaderia;
        lblCalificacion.Text = _paquete.Calificacion;
        lblHorario.Text = $"Hoy de {_paquete.Horario.Replace("Hoy ", "")}";
        lblPrecioAnterior.Text = _paquete.PrecioAnterior;
        lblPrecioActual.Text = _paquete.PrecioActual;
        lblTotalPagar.Text = _paquete.PrecioActual;

        ActualizarIconoFavorito();
    }

    private void ActualizarIconoFavorito()
    {
        if (_paquete == null) return;
        // Alterna entre corazón vacío (amor.png) y corazón rojo lleno (corazon.png)
        imgFavorito.Source = _paquete.EsFavorito ? "corazon.png" : "amor.png";
    }

    private async void OnRegresarTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void OnFavoritoTapped(object sender, TappedEventArgs e)
    {
        if (_paquete == null) return;

        _paquete.EsFavorito = !_paquete.EsFavorito;
        ActualizarIconoFavorito();
    }

    private async void OnComoLlegarClicked(object sender, EventArgs e)
    {
        if (_paquete == null) return;

        await DisplayAlert("Ubicación del establecimiento",
            $"{_paquete.Panaderia}\nDirección: {_paquete.Direccion}",
            "Entendido");
    }

    private async void OnReservarClicked(object sender, EventArgs e)
    {
        if (_paquete == null) return;
        await Shell.Current.GoToAsync(nameof(MetodoPagoPage));
    }

}