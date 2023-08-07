using DaleStore.Core.DTOs.VentaDetalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaleStore.Core.DTOs.Venta
{
    public class VentaInsertarDto
    {
        public int IdCliente { get; set; }

        public ICollection<VentaDetalleInsertarDto> VentaDetalle { get; set; }
    }
}
