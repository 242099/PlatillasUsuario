namespace PlantillasUsuario.Models;

public class SeccionPrincipalSelector : DataTemplateSelector
{
    public DataTemplate? InicioTemplate { get; set; }
    public DataTemplate? PedidosTemplate { get; set; }
    public DataTemplate? FavoritosTemplate { get; set; }

    protected override DataTemplate? OnSelectTemplate(object item, BindableObject container)
    {
        return item?.ToString() switch
        {
            "Inicio" => InicioTemplate,
            "Pedidos" => PedidosTemplate,
            "Favoritos" => FavoritosTemplate,
            _ => InicioTemplate
        };
    }
}