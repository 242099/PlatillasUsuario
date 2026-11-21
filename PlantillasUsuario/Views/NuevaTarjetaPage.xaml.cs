using PlantillasUsuario.Models;
using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class NuevaTarjetaPage : ContentPage
{
    public NuevaTarjetaPage()
    {
        InitializeComponent();
    }

    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnAgregarTarjetaClicked(object sender, EventArgs e)
    {
        string titular = txtTitular.Text?.Trim() ?? string.Empty;
        string numero = txtNumero.Text?.Trim() ?? string.Empty;
        string marca = txtMarca.Text?.Trim() ?? string.Empty;
        string vencimiento = txtVencimiento.Text?.Trim() ?? string.Empty;
        string cvv = txtCvv.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(titular) ||
            string.IsNullOrWhiteSpace(numero) ||
            string.IsNullOrWhiteSpace(marca) ||
            string.IsNullOrWhiteSpace(vencimiento) ||
            string.IsNullOrWhiteSpace(cvv))
        {
            await DisplayAlert("Datos incompletos", "Por favor rellena todos los datos de la tarjeta.", "Aceptar");
            return;
        }

        if (numero.Length < 4)
        {
            await DisplayAlert("Número inválido", "Ingresa al menos los últimos 4 dígitos de tu tarjeta.", "Aceptar");
            return;
        }

        if (!chkTerminos.IsChecked)
        {
            await DisplayAlert("Términos y condiciones", "Debes aceptar los términos y condiciones para continuar.", "Aceptar");
            return;
        }

        string ultimosCuatro = numero[^4..];

        DatosSimulados.TarjetaActual = new TarjetaPago
        {
            Titular = titular,
            NumeroEnmascarado = $"xxxx xxxx xxxx {ultimosCuatro}",
            Marca = marca,
            Vencimiento = vencimiento
        };

        await DisplayAlert("Tarjeta guardada", "Tu nueva tarjeta se ha establecido como método de pago.", "Continuar");
        await Shell.Current.GoToAsync("..");
    }
}