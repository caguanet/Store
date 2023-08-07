using System.Collections.Generic;

namespace DaleStore.Core.Entidades
{
    public partial class Venta
    {
        public Venta()
        {
            VentaDetalle = new HashSet<VentaDetalle>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<VentaDetalle> VentaDetalle { get; set; }
    }
}
