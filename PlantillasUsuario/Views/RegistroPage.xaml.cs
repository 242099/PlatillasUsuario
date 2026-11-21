using PlantillasUsuario.Services;

namespace PlantillasUsuario.Views;

public partial class RegistroPage : ContentPage
{
    public RegistroPage()
    {
        InitializeComponent();
    }

    private async void OnRegresarTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCrearCuentaClicked(object sender, EventArgs e)
    {
        string nombre = txtNombre.Text ?? string.Empty;
        string correo = txtCorreo.Text ?? string.Empty;
        string contrasena = txtContrasena.Text ?? string.Empty;
        string confirmar = txtConfirmarContrasena.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(correo) ||
            string.IsNullOrWhiteSpace(contrasena) ||
            string.IsNullOrWhiteSpace(confirmar))
        {
            await DisplayAlert("Campos incompletos", "Por favor rellena todos los campos para crear tu cuenta.", "Aceptar");
            return;
        }

        if (!correo.Contains('@') || !correo.Contains('.'))
        {
            await DisplayAlert("Correo inválido", "Ingresa un correo electrónico válido.", "Aceptar");
            return;
        }

        if (contrasena != confirmar)
        {
            await DisplayAlert("Contraseñas distintas", "La contraseña y su confirmación no coinciden.", "Aceptar");
            return;
        }

        bool registrado = DatosSimulados.RegistrarUsuario(nombre, correo, contrasena);

        if (!registrado)
        {
            await DisplayAlert("Correo existente", "Ya existe una cuenta registrada con ese correo electrónico.", "Aceptar");
            return;
        }

        await DisplayAlert("¡Cuenta creada!", $"Bienvenido {nombre.Trim()}. Ya puedes iniciar sesión con tu cuenta.", "Iniciar sesión");
        await Shell.Current.GoToAsync("..");
    }
}