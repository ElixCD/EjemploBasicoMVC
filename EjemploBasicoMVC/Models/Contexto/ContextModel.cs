namespace EjemploBasicoMVC.Models.Contexto
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=ContextModel")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<CompraDet> CompraDet { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Rel_ProductoProveedor> Rel_ProductoProveedor { get; set; }
        public virtual DbSet<Unidad> Unidad { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<VentaDet> VentaDet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.clave)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.limiteCredito)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Venta)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.cliente_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Compra>()
                .Property(e => e.noCompra)
                .IsUnicode(false);

            modelBuilder.Entity<Compra>()
                .Property(e => e.total)
                .HasPrecision(4, 4);

            modelBuilder.Entity<Compra>()
                .HasMany(e => e.CompraDet)
                .WithRequired(e => e.Compra)
                .HasForeignKey(e => e.compra_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.costo)
                .HasPrecision(4, 4);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.cantidad)
                .HasPrecision(4, 4);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.subtotal)
                .HasPrecision(4, 4);

            modelBuilder.Entity<CompraDet>()
                .Property(e => e.lote)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.clave)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.existencia)
                .HasPrecision(4, 4);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.CompraDet)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.producto_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Rel_ProductoProveedor)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.producto_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.VentaDet)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.producto_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.clave)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.Compra)
                .WithRequired(e => e.Proveedor)
                .HasForeignKey(e => e.proveedor_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.Rel_ProductoProveedor)
                .WithRequired(e => e.Proveedor)
                .HasForeignKey(e => e.proveedor_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unidad>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Unidad>()
                .Property(e => e.simbolo)
                .IsUnicode(false);

            modelBuilder.Entity<Unidad>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.Unidad)
                .HasForeignKey(e => e.unidad_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.clave)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Compra)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.usuario_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Venta)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.usuario_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.noVenta)
                .IsUnicode(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.total)
                .HasPrecision(4, 4);

            modelBuilder.Entity<Venta>()
                .HasMany(e => e.VentaDet)
                .WithRequired(e => e.Venta)
                .HasForeignKey(e => e.venta_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VentaDet>()
                .Property(e => e.precio)
                .HasPrecision(4, 4);

            modelBuilder.Entity<VentaDet>()
                .Property(e => e.cantidad)
                .HasPrecision(4, 4);

            modelBuilder.Entity<VentaDet>()
                .Property(e => e.subtotal)
                .HasPrecision(4, 4);
        }
    }
}
