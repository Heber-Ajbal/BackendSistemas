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
        public async Task<LoginResponse> CrearEmpleadoConUsuario(
        string nombreEmpleado,
        string apellidoPaterno,
        string apellidoMaterno,
        string turno,
        string cargo,
        double sueldo,
        string nombreUsuario,
        string contrasena,
        string rol
    )
        {
            var context = _contextFactory.CreateDbContext();

            // 1. Crear el empleado
            var empleado = new Empleado
            {
                Nombre = nombreEmpleado,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                Sueldo = (decimal?)sueldo,
                Turno = turno,
                Cargo = cargo
            };

            context.Empleados.Add(empleado);
            await context.SaveChangesAsync();

            // 2. Calcular hash de la contraseña
            string hash = CalcularSha256(contrasena);

            // 3. Crear el usuario
            var usuario = new Usuario
            {
                IdEmpleado = empleado.IdEmpleado,
                NombreUsuario = nombreUsuario,
                ContrasenaHash = hash,
                Rol = rol,
                Activo = true
            };

            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();

            return new LoginResponse
            {
                Exito = true,
                Mensaje = "Usuario creado correctamente",
                Usuario = usuario,
            };
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

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CLAVESECRETA_SUPERMERCADO_2024_+segura")); // reemplaza por algo más seguro
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
