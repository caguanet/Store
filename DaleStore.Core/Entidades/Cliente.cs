using System.Collections.Generic;

namespace DaleStore.Core.Entidades
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
