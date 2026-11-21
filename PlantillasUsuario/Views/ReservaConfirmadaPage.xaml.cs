using PlantillasUsuario.Models;
using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class ReservaConfirmadaPage : ContentPage
{
    private PedidoReservado? _pedido;

    public ReservaConfirmadaPage()
    {
        InitializeComponent();
        CargarDatosReserva();
    }

    private void CargarDatosReserva()
    {
        _pedido = DatosSimulados.UltimoPedido;
        if (_pedido == null) return;

        lblBannerMetodo.Text = _pedido.MetodoPago;
        lblCodigoPedido.Text = _pedido.CodigoPedido;

        var p = _pedido.Paquete;
        string horario = p.Horario.Contains('-') ? p.Horario.Split('-').Last().Trim() : p.Horario;

        lblPanaderia.Text = $"📍 {p.Panaderia}";
        lblHorarioLimite.Text = $"🕒 Horario límite: Hoy hasta las {horario} hrs";
        lblPaquete.Text = $"📦 1x {p.NombrePaquete}";

        string etiquetaMonto = _pedido.MetodoPago.Contains("TARJETA")
            ? $"💳 Total pagado: {p.PrecioActual}"
            : $"💵 Total a pagar en caja: {p.PrecioActual}";
        lblMonto.Text = etiquetaMonto;
    }

    private async void OnComoLlegarClicked(object sender, EventArgs e)
    {
        if (_pedido == null) return;

        await DisplayAlert("Cómo llegar",
            $"{_pedido.Paquete.Panaderia}\nDirección: {_pedido.Paquete.Direccion}",
            "Entendido");
    }

    private async void OnVerMisPedidosClicked(object sender, EventArgs e)
    {
        DatosSimulados.PestanaInicial = 1; // Abre directamente en Pedidos
        await Shell.Current.GoToAsync("//PrincipalPage");
    }
}