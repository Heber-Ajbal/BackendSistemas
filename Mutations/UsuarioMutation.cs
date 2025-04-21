using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class UsuarioMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UsuarioMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Crear un nuevo usuario
        public async Task<Usuario> CrearUsuario(Usuario input)
        {
            var context = _contextFactory.CreateDbContext();
            context.Usuarios.Add(input);
            await context.SaveChangesAsync();
            return input;
        }

        // Actualizar un usuario existente
        public async Task<Usuario?> ActualizarUsuario(int id, Usuario input)
        {
            var context = _contextFactory.CreateDbContext();
            var usuario = await context.Usuarios.FindAsync(id);
            if (usuario == null) return null;

            usuario.IdEmpleado = input.IdEmpleado ?? usuario.IdEmpleado;
            usuario.NombreUsuario = input.NombreUsuario ?? usuario.NombreUsuario;
            usuario.ContrasenaHash = input.ContrasenaHash ?? usuario.ContrasenaHash;
            usuario.Activo = input.Activo ?? usuario.Activo;
            usuario.Rol = input.Rol ?? usuario.Rol;

            await context.SaveChangesAsync();
            return usuario;
        }

        // Eliminar un usuario
        public async Task<bool> EliminarUsuario(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var usuario = await context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
