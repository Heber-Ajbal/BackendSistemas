namespace Supermercado.Models
{
    public partial class ProductoCInput
    {
        public string Nombre { get; set; } = null!;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int IdCategoria { get; set; }
        public string? Imagen { get; set; } 
    }
}
