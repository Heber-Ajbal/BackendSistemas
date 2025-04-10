using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class AlmacenMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public AlmacenMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Almacen> CrearAlmacen(Almacen input)
        {
            var context = _contextFactory.CreateDbContext();
            context.Almacens.Add(input); 
            await context.SaveChangesAsync();
            return input;
        }

        public async Task<Almacen?> ActualizarAlmacen(int id, Almacen input)
        {
            var context = _contextFactory.CreateDbContext();
            var almacen = await context.Almacens.FindAsync(id);
            if (almacen == null) return null;

            almacen.Nombre = input.Nombre;
            almacen.Ubicacion = input.Ubicacion;
            almacen.Capacidad = input.Capacidad;

            await context.SaveChangesAsync();
            return almacen;
        }

        public async Task<bool> EliminarAlmacen(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var almacen = await context.Almacens.FindAsync(id);
            if (almacen == null) return false;

            context.Almacens.Remove(almacen);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
