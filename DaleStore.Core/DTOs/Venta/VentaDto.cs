using DaleStore.Core.DTOs.VentaDetalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaleStore.Core.DTOs.Venta
{
    public class VentaDto
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public decimal ValorTotal { get; set; }

    }
}
