using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Supermercado.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public async Task<LoginResponse> Login(string nombreUsuario, string contrasena)
        {
            var context = _contextFactory.CreateDbContext();
            var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);

            if (usuario == null)
            {
                return new LoginResponse { Exito = false, Mensaje = "Usuario no encontrado" };
            }

            string hash = CalcularSha256(contrasena);

            if (usuario.ContrasenaHash != hash)
            {
                return new LoginResponse { Exito = false, Mensaje = "Contraseña incorrecta" };
            }

            string token = GenerarToken(usuario);

            return new LoginResponse
            {
                Exito = true,
                Mensaje = "Login exitoso",
                Usuario = usuario,
                Token = token
            };
        }

        private string GenerarToken(Usuario usuario)
        {
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, usuario.NombreUsuario),
        new Claim("id", usuario.IdUsuario.ToString()),
        new Claim(ClaimTypes.Role, usuario.Rol ?? "Empleado")
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CLAVESECRETA_SUPERMERCADO")); // reemplaza por algo más seguro
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "SupermercadoAPI",
                audience: "SupermercadoFront",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(6),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private static string CalcularSha256(string input)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }

    }
}
