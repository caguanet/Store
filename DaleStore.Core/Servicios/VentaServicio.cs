using DaleStore.Core.Entidades;
using DaleStore.Core.Excepciones;
using DaleStore.Core.Interfaces;
using DaleStore.Core.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaleStore.Core.Servicios
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        public VentaServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Venta> InsertVenta(Venta venta)
        {
            var objCliente = await _unitOfWork.ClienteRepositorio.GetxId(venta.IdCliente);
            if (objCliente == null)
                throw new NegocioException("El cliente no existe.");


            venta.ValorTotal = venta.VentaDetalle.Sum(s => s.ValorUnitario * s.Cantidad);
            await _unitOfWork.VentaRepositorio.Add(venta);
            await _unitOfWork.SaveChangesAsync();
            return await _unitOfWork.VentaRepositorio.GetIncClientexId(venta.Id);
        }
    }
}
