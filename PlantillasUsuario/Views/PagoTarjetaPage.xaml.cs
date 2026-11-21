using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class PagoTarjetaPage : ContentPage
{
    public PagoTarjetaPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarDatos();
    }

    private void CargarDatos()
    {
        var tarjeta = DatosSimulados.TarjetaActual;
        var paquete = DatosSimulados.PaqueteSeleccionado;

        lblNumeroTarjeta.Text = tarjeta.NumeroEnmascarado;
        lblTitular.Text = $"Titular : {tarjeta.Titular}";

        string precio = paquete?.PrecioActual ?? "$30 MXN";
        lblPreguntaCobro.Text = $"¿Estás seguro de autorizar el cobro de {precio}\na esta tarjeta?";
    }

    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnUsarOtraTarjetaTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NuevaTarjetaPage));
    }

    private async void OnAutorizarPagoClicked(object sender, EventArgs e)
    {
        var paquete = DatosSimulados.PaqueteSeleccionado;
        if (paquete == null) return;

        DatosSimulados.RegistrarPedido(paquete, "PAGADO CON TARJETA");
        await Shell.Current.GoToAsync(nameof(ReservaConfirmadaPage));
    }
}