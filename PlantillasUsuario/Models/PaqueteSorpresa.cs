namespace PlantillasUsuario.Models;

public class PaqueteSorpresa
{
    public int Id { get; set; }
    public string Panaderia { get; set; } = string.Empty;
    public string NombrePaquete { get; set; } = string.Empty;
    public string Descuento { get; set; } = string.Empty;
    public string Imagen { get; set; } = string.Empty;
    public string Horario { get; set; } = string.Empty;
    public string PrecioAnterior { get; set; } = string.Empty;
    public string PrecioActual { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public int Disponibles { get; set; } = 3;
    public bool EsFavorito { get; set; }

    // Datos del Perfil del Negocio
    public string Calificacion { get; set; } = "4.7 (924)";
    public string TiempoPlataforma { get; set; } = "1 año";
    public string PaquetesSalvados { get; set; } = "+5,000";
    public string AcercaDe { get; set; } = "Somos una panaderia artesanal comprometida con la sustentabilidad y el horneado diario de alta calidad.";

    // Propiedades visuales para la tarjeta de Favoritos
    public string TextoEstado => Disponibles > 0 ? "Disponible" : "Agotado";
    public Color ColorEstado => Disponibles > 0 ? Color.FromArgb("#D9F7E6") : Color.FromArgb("#FFFFFF");
    public string HorarioRecoger => $"Recoger {Horario.Replace("Hoy ", "hoy ")}";
}