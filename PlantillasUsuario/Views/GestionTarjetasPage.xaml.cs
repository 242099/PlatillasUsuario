using PlantillasUsuario.Models;
using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class GestionTarjetasPage : ContentPage
{
    private TarjetaPago? _tarjetaParaEliminar;

    public GestionTarjetasPage()
    {
        InitializeComponent();
        cvTarjetas.ItemsSource = DatosSimulados.Tarjetas;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Oculta el botón rojo de seguridad cada vez que se entra o regresa a la pantalla
        _tarjetaParaEliminar = null;
        btnConfirmarEliminar.IsVisible = false;
    }

    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void OnBoteBasuraClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton btn && btn.CommandParameter is TarjetaPago tarjeta)
        {
            ActivarBotonSeguridad(tarjeta);
        }
    }

    private void OnTextoEliminarTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is TarjetaPago tarjeta)
        {
            ActivarBotonSeguridad(tarjeta);
        }
    }

    private void ActivarBotonSeguridad(TarjetaPago tarjeta)
    {
        _tarjetaParaEliminar = tarjeta;
        btnConfirmarEliminar.Text = $"Eliminar Tarjeta ({tarjeta.NumeroEnmascarado[^4..]})";
        btnConfirmarEliminar.IsVisible = true;
    }

    private async void OnConfirmarEliminarClicked(object sender, EventArgs e)
    {
        if (_tarjetaParaEliminar == null) return;

        DatosSimulados.Tarjetas.Remove(_tarjetaParaEliminar);

        // Si quedan otras tarjetas y ninguna es predeterminada, marca la primera como predeterminada
        if (DatosSimulados.Tarjetas.Count > 0 && !DatosSimulados.Tarjetas.Any(t => t.EsPredeterminada))
        {
            DatosSimulados.Tarjetas[0].EsPredeterminada = true;
            // Refresca la lista visualmente
            cvTarjetas.ItemsSource = null;
            cvTarjetas.ItemsSource = DatosSimulados.Tarjetas;
        }

        _tarjetaParaEliminar = null;
        btnConfirmarEliminar.IsVisible = false;

        await DisplayAlert("Tarjeta eliminada", "La tarjeta ha sido eliminada del sistema.", "Aceptar");
    }

    private async void OnAgregarTarjetaClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NuevaTarjetaPage));
    }
}