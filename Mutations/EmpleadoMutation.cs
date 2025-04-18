﻿using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class EmpleadoMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public EmpleadoMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Crear un nuevo empleado
        public async Task<Empleado> CrearEmpleado(Empleado input)
        {
            var context = _contextFactory.CreateDbContext();
            context.Empleados.Add(input);  
            await context.SaveChangesAsync();
            return input;
        }

        // Actualizar un empleado existente
        public async Task<Empleado?> ActualizarEmpleado(int id, Empleado input)
        {
            var context = _contextFactory.CreateDbContext();
            var empleado = await context.Empleados.FindAsync(id);
            if (empleado == null) return null;

            empleado.Nombre = input.Nombre ?? empleado.Nombre;
            empleado.ApellidoPaterno = input.ApellidoPaterno ?? empleado.ApellidoPaterno;
            empleado.ApellidoMaterno = input.ApellidoMaterno ?? empleado.ApellidoMaterno;
            empleado.Sueldo = input.Sueldo ?? empleado.Sueldo;
            empleado.Turno = input.Turno ?? empleado.Turno;
            empleado.Cargo = input.Cargo ?? empleado.Cargo;

            await context.SaveChangesAsync();
            return empleado;
        }

        // Eliminar un empleado
        public async Task<bool> EliminarEmpleado(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var empleado = await context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            context.Empleados.Remove(empleado);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
