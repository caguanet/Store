using System.Collections.Generic;

namespace DaleStore.Core.Entidades
{
    public partial class Producto
    {
        public Producto()
        {
            VentaDetalle = new HashSet<VentaDetalle>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnitario { get; set; }

        public virtual ICollection<VentaDetalle> VentaDetalle { get; set; }
    }
}
