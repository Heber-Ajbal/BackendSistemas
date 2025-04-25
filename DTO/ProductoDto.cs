namespace Supermercado.DTO
{
    public class ProductoDto
    {
        public int? CodProducto { get; set; }
        public string? Nombre { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? IdCategoria { get; set; }
        public string? ImagenBase64 { get; set; }
    }
}
