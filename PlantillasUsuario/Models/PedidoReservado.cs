namespace PlantillasUsuario.Models;

public class PedidoReservado
{
    public string CodigoPedido { get; set; } = string.Empty;
    public PaqueteSorpresa Paquete { get; set; } = new();
    public string MetodoPago { get; set; } = string.Empty;
    public string Estado { get; set; } = "PENDIENTE";
    public string FechaTexto { get; set; } = "Hoy";
    public DateTime FechaReserva { get; set; } = DateTime.Now;

    public string CodigoFormateado => $"RES - {CodigoPedido}";
}