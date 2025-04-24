namespace Supermercado.Models
{
    public class VentaCInput
    {

        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public decimal Monto { get; set; }

        public List<DetalleVentaCInput> Detalles { get; set; } = new();
    }

    public class DetalleVentaCInput
    {
        public int CodProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
    }
}
