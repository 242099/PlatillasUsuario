using PlantillasUsuario.Views;

namespace PlantillasUsuario;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(RegistroPage), typeof(RegistroPage));
        Routing.RegisterRoute(nameof(PerfilNegocioPage), typeof(PerfilNegocioPage));
        Routing.RegisterRoute(nameof(DetallePaquetePage), typeof(DetallePaquetePage));
        Routing.RegisterRoute(nameof(MetodoPagoPage), typeof(MetodoPagoPage));
        Routing.RegisterRoute(nameof(PagoTarjetaPage), typeof(PagoTarjetaPage));
        Routing.RegisterRoute(nameof(NuevaTarjetaPage), typeof(NuevaTarjetaPage));
        Routing.RegisterRoute(nameof(PagoEfectivoPage), typeof(PagoEfectivoPage));
        Routing.RegisterRoute(nameof(ReservaConfirmadaPage), typeof(ReservaConfirmadaPage));
        Routing.RegisterRoute(nameof(MisPedidosPage), typeof(MisPedidosPage));
        Routing.RegisterRoute(nameof(PerfilUsuarioPage), typeof(PerfilUsuarioPage));
        Routing.RegisterRoute(nameof(GestionTarjetasPage), typeof(GestionTarjetasPage));
    }
}