using DaleStore.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DaleStore.Infraestructura.Data
{
    public partial class DaleStoreContext : DbContext
    {
        public DaleStoreContext()
        {
        }

        public DaleStoreContext(DbContextOptions<DaleStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<VentaDetalle> VentaDetalle { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
              
    }
}
