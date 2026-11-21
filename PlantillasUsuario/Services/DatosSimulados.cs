using System.Collections.ObjectModel;
using PlantillasUsuario.Models;

namespace PlantillasUsuario.Services;

public static class DatosSimulados
{
    public static List<Usuario> Usuarios { get; } = new()
    {
        new Usuario
        {
            Nombre = "Daniel Ortega",
            Correo = "admin@provecha.com",
            Contrasena = "123"
        }
    };

    public static Usuario? UsuarioActual { get; set; }

    // Paquete que el usuario toca para ver su detalle
    public static PaqueteSorpresa? PaqueteSeleccionado { get; set; }

    // Lista en memoria con los paquetes de Atlixco, Puebla
    public static ObservableCollection<PaqueteSorpresa> Paquetes { get; } = new()
    {
        new PaqueteSorpresa
        {
            Id = 1,
            Panaderia = "Panadería \"La Espiga de Oro\"",
            NombrePaquete = "Paquete Sorpresa 3pza",
            Descuento = "50% OFF",
            Imagen = "panaderia_espiga.jpg",
            Horario = "Hoy 18:00 - 20:00",
            PrecioAnterior = "$60",
            PrecioActual = "$30 MXN",
            Descripcion = "Surtido variado de pan dulce tradicional recién horneado del día (conchas, cuernitos y orejas).",
            Direccion = "Centro Atlixco Pue, Calle 5 sur",
            Disponibles = 4,
            EsFavorito = false
        },
        new PaqueteSorpresa
        {
            Id = 2,
            Panaderia = "Panadería \"Rosales Turquesa\"",
            NombrePaquete = "Paquete Sorpresa 2",
            Descuento = "50% OFF",
            Imagen = "panaderia_rosales.jpg",
            Horario = "Hoy 20:30 - 21:00",
            PrecioAnterior = "$60",
            PrecioActual = "$30 MXN",
            Descripcion = "Paquete familiar con repostería fina, pan de dulce y bolillos artesanales.",
            Direccion = "Calle 3 Sur 115, Atlixco, Pue.",
            Disponibles = 0,
            EsFavorito = false
        },
        new PaqueteSorpresa
        {
            Id = 3,
            Panaderia = "Panadería \"El fino\"",
            NombrePaquete = "Paquete sorpresa 3",
            Descuento = "65% OFF",
            Imagen = "panaderia_fino.jpg",
            Horario = "Hoy 19:00 - 20:30",
            PrecioAnterior = "$110",
            PrecioActual = "$40 MXN",
            Descripcion = "Selección especial de tartaletas, panqués y piezas dulces del mostrador.",
            Direccion = "Blvd. Ferrocarriles 810, Atlixco, Pue.",
            Disponibles = 5,
            EsFavorito = false
        }
    };

    // Lista de tarjetas guardadas en el sistema
    public static ObservableCollection<TarjetaPago> Tarjetas { get; } = new()
    {
        new TarjetaPago
        {
            Titular = "Daniel Ortega G.",
            NumeroEnmascarado = "XXXX XXXX XXXX 4321",
            Marca = "Visa",
            Vencimiento = "12/28",
            EsPredeterminada = true
        }
    };

    // Propiedad conectada a la lista de tarjetas (siempre devuelve o establece la predeterminada)
    public static TarjetaPago TarjetaActual
    {
        get => Tarjetas.FirstOrDefault() ?? new TarjetaPago
        {
            Titular = "Sin tarjeta",
            NumeroEnmascarado = "Agrega una tarjeta",
            Vencimiento = "--/--"
        };
        set
        {
            foreach (var t in Tarjetas)
                t.EsPredeterminada = false;

            value.EsPredeterminada = true;
            Tarjetas.Insert(0, value);
        }
    }

    // Lista de pedidos reservados en la sesión
    public static ObservableCollection<PedidoReservado> Pedidos { get; } = new();

    // Último pedido confirmado para mostrarlo en ReservaConfirmadaPage

    // Controla en qué pestaña abrir PrincipalPage (0 = Inicio, 1 = Pedidos, 2 = Favoritos)
    public static int PestanaInicial { get; set; } = 0;

    public static PedidoReservado? UltimoPedido { get; set; }

    public static bool IniciarSesion(string correo, string contrasena)
    {
        var usuario = Usuarios.FirstOrDefault(u =>
            u.Correo.Equals(correo.Trim(), StringComparison.OrdinalIgnoreCase) &&
            u.Contrasena == contrasena);

        if (usuario != null)
        {
            UsuarioActual = usuario;
            return true;
        }
        return false;
    }

    public static bool RegistrarUsuario(string nombre, string correo, string contrasena)
    {
        bool existe = Usuarios.Any(u =>
            u.Correo.Equals(correo.Trim(), StringComparison.OrdinalIgnoreCase));

        if (existe) return false;

        Usuarios.Add(new Usuario
        {
            Nombre = nombre.Trim(),
            Correo = correo.Trim(),
            Contrasena = contrasena
        });
        return true;
    }

    public static PedidoReservado RegistrarPedido(PaqueteSorpresa paquete, string metodoPago)
    {
        bool esTarjeta = metodoPago.Contains("TARJETA", StringComparison.OrdinalIgnoreCase);

        var pedido = new PedidoReservado
        {
            CodigoPedido = $"{Random.Shared.Next(1000, 9999)}-2026",
            Paquete = paquete,
            MetodoPago = metodoPago,
            Estado = esTarjeta ? "PAGADO" : "PENDIENTE",
            FechaTexto = "Hoy",
            FechaReserva = DateTime.Now
        };

        UltimoPedido = pedido;
        Pedidos.Insert(0, pedido);
        return pedido;
    }

    // Lista observable que alimenta en tiempo real la pestaña Favoritos del carrusel
    public static ObservableCollection<PaqueteSorpresa> FavoritosActivos { get; } = new();

    public static void AlternarFavorito(PaqueteSorpresa paquete)
    {
        paquete.EsFavorito = !paquete.EsFavorito;

        if (paquete.EsFavorito)
        {
            if (!FavoritosActivos.Contains(paquete))
                FavoritosActivos.Add(paquete);
        }
        else
        {
            FavoritosActivos.Remove(paquete);
        }
    }
}