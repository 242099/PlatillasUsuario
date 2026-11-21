using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnIniciarSesionClicked(object sender, EventArgs e)
    {
        string correo = txtCorreo.Text ?? string.Empty;
        string contrasena = txtContrasena.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
        {
            await DisplayAlert("Campos incompletos", "Por favor ingresa tu correo y contraseña.", "Aceptar");
            return;
        }

        if (DatosSimulados.IniciarSesion(correo, contrasena))
        {
            txtCorreo.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            await Shell.Current.GoToAsync("//BienvenidaPage");
        }
        else
        {
            await DisplayAlert("Acceso denegado", "Correo o contraseña incorrectos.\n\nPrueba con:\nadmin@provecha.com / 123", "Reintentar");
        }
    }

    private async void OnRegistrateTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RegistroPage));
    }
}