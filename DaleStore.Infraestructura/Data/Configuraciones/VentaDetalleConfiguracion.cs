using DaleStore.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaleStore.Infraestructura.Data.Configuraciones
{
    public class VentaDetalleConfiguracion : IEntityTypeConfiguration<VentaDetalle>
    {
        public void Configure(EntityTypeBuilder<VentaDetalle> builder)
        {
            builder.ToTable("VENTADETALLE");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.IdProducto).HasColumnName("Id_Producto");

            builder.Property(e => e.IdVenta).HasColumnName("Id_Venta");

            builder.Property(e => e.ValorUnitario).HasColumnType("money");

            builder.HasOne(d => d.IdProductoNavigation)
                .WithMany(p => p.VentaDetalle)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VENTADETALLE_PRODUCTO");

            builder.HasOne(d => d.IdVentaNavigation)
                .WithMany(p => p. VentaDetalle)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VENTADETALLE_VENTA");


        }
    }
}
