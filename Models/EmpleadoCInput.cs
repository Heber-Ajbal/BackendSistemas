namespace Supermercado.Models
{
    public partial class EmpleadoCInput
    {
        public int? IdEmpleado { get; set; }

        public string? Nombre { get; set; }

        public string? ApellidoPaterno { get; set; }

        public string? ApellidoMaterno { get; set; }

        public decimal? Sueldo { get; set; }

        public string? Turno { get; set; }

        public string? Cargo { get; set; }
    }
}
