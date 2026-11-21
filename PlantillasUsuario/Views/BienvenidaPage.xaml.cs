using PlantillasUsuario.Models;

namespace PlantillasUsuario.Views;

public partial class BienvenidaPage : ContentPage
{
    private readonly List<PasoBienvenida> _pasos;

    public BienvenidaPage()
    {
        InitializeComponent();

        _pasos = new List<PasoBienvenida>
        {
            new PasoBienvenida
            {
                Imagen = "onboarding_tienda.png",
                Titulo = "Rescata comida",
                Descripcion = "Explora ofertas exclusivas de paquetes sorpresa en tu establecimiento favorito"
            },
            new PasoBienvenida
            {
                Imagen = "onboarding_sorpresa.png",
                Titulo = "Contenido sorpresa",
                Descripcion = "Cada paquete varía diariamente con los excedentes del día en perfecto estado"
            },
            new PasoBienvenida
            {
                Imagen = "onboarding_qr.png",
                Titulo = "Recoger en tienda",
                Descripcion = "Muestra el código QR de tu pedido en el establecimiento durante la ventana de recolección"
            }
        };

        carruselBienvenida.ItemsSource = _pasos;
    }

    private void OnCarruselPositionChanged(object sender, PositionChangedEventArgs e)
    {
        // Cambia el texto del botón si está en la última diapositiva
        if (e.CurrentPosition == _pasos.Count - 1)
            btnAccion.Text = "Comenzar";
        else
            btnAccion.Text = "Siguiente";
    }

    private async void OnAccionClicked(object sender, EventArgs e)
    {
        if (carruselBienvenida.Position < _pasos.Count - 1)
        {
            // Avanza a la siguiente diapositiva del carrusel
            carruselBienvenida.Position += 1;
        }
        else
        {
            // Al dar clic en "Comenzar", entra a la pantalla principal de la app
            await Shell.Current.GoToAsync("//PrincipalPage");
        }
    }
}