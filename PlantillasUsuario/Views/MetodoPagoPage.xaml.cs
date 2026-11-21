namespace PlantillasUsuario.Views;

public partial class MetodoPagoPage : ContentPage
{
    private bool _esTarjeta = true;

    public MetodoPagoPage()
    {
        InitializeComponent();
        ActualizarSeleccion();
    }

    private void ActualizarSeleccion()
    {
        if (_esTarjeta)
        {
            cardTarjeta.Stroke = Color.FromArgb("#C85A28");
            cardTarjeta.StrokeThickness = 2;
            cardEfectivo.Stroke = Color.FromArgb("#E5E5E5");
            cardEfectivo.StrokeThickness = 1;
        }
        else
        {
            cardTarjeta.Stroke = Color.FromArgb("#E5E5E5");
            cardTarjeta.StrokeThickness = 1;
            cardEfectivo.Stroke = Color.FromArgb("#C85A28");
            cardEfectivo.StrokeThickness = 2;
        }
    }

    private void OnSeleccionarTarjetaTapped(object sender, TappedEventArgs e)
    {
        _esTarjeta = true;
        ActualizarSeleccion();
    }

    private void OnSeleccionarEfectivoTapped(object sender, TappedEventArgs e)
    {
        _esTarjeta = false;
        ActualizarSeleccion();
    }

    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnContinuarClicked(object sender, EventArgs e)
    {
        if (_esTarjeta)
            await Shell.Current.GoToAsync(nameof(PagoTarjetaPage));
        else
            await Shell.Current.GoToAsync(nameof(PagoEfectivoPage));
    }
}