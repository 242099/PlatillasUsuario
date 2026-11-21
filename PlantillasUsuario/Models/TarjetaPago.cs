namespace PlantillasUsuario.Models;

public class TarjetaPago
{
    public string Titular { get; set; } = string.Empty;
    public string NumeroEnmascarado { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Vencimiento { get; set; } = string.Empty;
    public bool EsPredeterminada { get; set; } = true;
}