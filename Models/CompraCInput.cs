namespace Supermercado.Models
{
    public class CompraCInput
    {
        public int CodProveedor { get; set; }
        public int IdEmpleado { get; set; }
        public decimal Monto { get; set; }
        public DateOnly Fecha { get; set; }
        public string TipoPago { get; set; }
        public List<DetalleCompraCInput> DetalleCompras { get; set; } = new();   
            
        
    }
}
