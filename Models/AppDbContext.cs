using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Supermercado.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacen> Almacens { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<MovimientosAlmacen> MovimientosAlmacens { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasKey(e => e.IdAlmacen).HasName("PK__ALMACEN__5FC485CF23AA59B6");

            entity.ToTable("ALMACEN");

            entity.Property(e => e.IdAlmacen).HasColumnName("idAlmacen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__8A3D240C555D1272");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__CLIENTE__885457EEDF514131");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Paterno");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__COMPRA__48B99DB76BB14F66");

            entity.ToTable("COMPRA");

            entity.Property(e => e.IdCompra).HasColumnName("idCompra");
            entity.Property(e => e.CodProveedor).HasColumnName("codProveedor");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Tipo_pago");

            entity.HasOne(d => d.CodProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.CodProveedor)
                .HasConstraintName("FK__COMPRA__codProve__286302EC");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__COMPRA__idEmplea__29572725");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__DETALLE___62C252C13DF81616");

            entity.ToTable("DETALLE_COMPRA");

            entity.Property(e => e.IdDetalleCompra).HasColumnName("idDetalleCompra");
            entity.Property(e => e.CodProducto).HasColumnName("codProducto");
            entity.Property(e => e.IdCompra).HasColumnName("idCompra");
            entity.Property(e => e.PrecioProducto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_producto");

            entity.HasOne(d => d.CodProductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.CodProducto)
                .HasConstraintName("FK__DETALLE_C__codPr__2D27B809");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK__DETALLE_C__idCom__2C3393D0");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__DETALLE___BFE2843F122D4463");

            entity.ToTable("DETALLE_VENTA");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");
            entity.Property(e => e.CodProducto).HasColumnName("codProducto");
            entity.Property(e => e.Descuento).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");

            entity.HasOne(d => d.CodProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.CodProducto)
                .HasConstraintName("FK__DETALLE_V__codPr__34C8D9D1");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__DETALLE_V__idVen__33D4B598");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__EMPLEADO__5295297C4EE96C6C");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Paterno");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sueldo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Turno)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("PK__INVENTAR__8F145B0D1915AFDD");

            entity.ToTable("INVENTARIO");

            entity.Property(e => e.IdInventario).HasColumnName("idInventario");
            entity.Property(e => e.CodProducto).HasColumnName("codProducto");
            entity.Property(e => e.IdAlmacen).HasColumnName("idAlmacen");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodProductoNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.CodProducto)
                .HasConstraintName("FK__INVENTARI__codPr__22AA2996");

            entity.HasOne(d => d.IdAlmacenNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdAlmacen)
                .HasConstraintName("FK__INVENTARI__idAlm__239E4DCF");
        });

        modelBuilder.Entity<MovimientosAlmacen>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PK__MOVIMIEN__62852173B0D8F079");

            entity.ToTable("MOVIMIENTOS_ALMACEN");

            entity.Property(e => e.IdMovimiento).HasColumnName("idMovimiento");
            entity.Property(e => e.CodProducto).HasColumnName("codProducto");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodProductoNavigation).WithMany(p => p.MovimientosAlmacens)
                .HasForeignKey(d => d.CodProducto)
                .HasConstraintName("FK__MOVIMIENT__codPr__398D8EEE");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.MovimientosAlmacens)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__MOVIMIENT__idEmp__3A81B327");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodProducto).HasName("PK__PRODUCTO__59E87D7C41BA594E");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.CodProducto).HasColumnName("codProducto");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioCompra)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_compra");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_venta");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__PRODUCTO__idCate__1ED998B2");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.CodProveedor).HasName("PK__PROVEEDO__26E566FBF6A59108");

            entity.ToTable("PROVEEDORES");

            entity.Property(e => e.CodProveedor).HasColumnName("codProveedor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__645723A656A5E810");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.IdEmpleado, "UQ__USUARIO__5295297DFE21C6A1").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "UQ__USUARIO__6B0F5AE07A86708C").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.ContrasenaHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.IdEmpleado)
                .HasConstraintName("FK__USUARIO__idEmple__182C9B23");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__VENTA__077D56148427B269");

            entity.ToTable("VENTA");

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__VENTA__idCliente__300424B4");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__VENTA__idEmplead__30F848ED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
