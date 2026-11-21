using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class PagoEfectivoPage : ContentPage
{
    public PagoEfectivoPage()
    {
        InitializeComponent();
        CargarDatos();
    }

    private void CargarDatos()
    {
        var paquete = DatosSimulados.PaqueteSeleccionado;
        lblMontoCaja.Text = paquete?.PrecioActual ?? "$30 MXN";

        string horario = paquete?.Horario ?? "Hoy 18:00 - 20:00";
        // Extrae la hora final si viene en formato "Hoy 18:00 - 20:00"
        string horaFinal = horario.Contains('-') ? horario.Split('-').Last().Trim() : horario;
        lblHorarioLimite.Text = $"Hoy hasta las {horaFinal}";
    }

    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCambiarMetodoTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnConfirmarEfectivoClicked(object sender, EventArgs e)
    {
        if (!chkCompromiso.IsChecked)
        {
            await DisplayAlert("Compromiso requerido",
                "Por favor marca la casilla comprometiéndote a acudir dentro del horario indicado.",
                "Aceptar");
            return;
        }

        var paquete = DatosSimulados.PaqueteSeleccionado;
        if (paquete == null) return;

        DatosSimulados.RegistrarPedido(paquete, "PAGADO CON EFECTIVO");
        await Shell.Current.GoToAsync(nameof(ReservaConfirmadaPage));
    }
}