using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class ClienteMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ClienteMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Cliente> CrearCliente(Cliente input)
        {
            var context = _contextFactory.CreateDbContext();
            context.Clientes.Add(input);
            await context.SaveChangesAsync();
            return input;
        }

        public async Task<Cliente?> ActualizarCliente(int id, Cliente input)
        {
            var context = _contextFactory.CreateDbContext();
            var cliente = await context.Clientes.FindAsync(id);
            if (cliente == null) return null;

            cliente.Nombre = input.Nombre;
            cliente.ApellidoPaterno = input.ApellidoPaterno;
            cliente.ApellidoMaterno = input.ApellidoMaterno;
            cliente.Direccion = input.Direccion;
            cliente.Telefono = input.Telefono;

            await context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> EliminarCliente(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var cliente = await context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
