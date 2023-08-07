using System;
using System.Collections.Generic;
using System.Text;

namespace DaleStore.Core.DTOs.VentaDetalle
{
   public class VentaDetalleInsertarDto
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public short Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }


    }
}
