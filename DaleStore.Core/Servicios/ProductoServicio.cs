using DaleStore.Core.Entidades;
using DaleStore.Core.Excepciones;
using DaleStore.Core.Interfaces;
using DaleStore.Core.Interfaces.Servicios;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DaleStore.Core.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteProducto(int id)
        {

            await ValidarPorId(id);
            var total = await _unitOfWork.ProductoRepositorio.GetTotalVendidosxId(id);
            if (total > 0)
                throw new NegocioException("No se puede eliminar ya que tiene registros asociados.");

            var respuesta = await _unitOfWork.ProductoRepositorio.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return respuesta;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _unitOfWork.ProductoRepositorio.Get();
        }
        public async Task<Producto> GetProductoxId(int id)
        {
            return await _unitOfWork.ProductoRepositorio.GetxId(id);
        }

        public async Task<Producto> InsertProducto(Producto producto)
        {
            await _unitOfWork.ProductoRepositorio.Add(producto);
            await _unitOfWork.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> UpdateProducto(Producto producto)
        {
            await ValidarPorId(producto.Id);

            var respuesta = _unitOfWork.ProductoRepositorio.Update(producto);
            await _unitOfWork.SaveChangesAsync();
            return respuesta;

        }

        private async Task  ValidarPorId(int id) {

            var objProcducto = await _unitOfWork.ProductoRepositorio.GetxId(id);
            if (objProcducto == null)
                throw new NegocioException("El producto no existe.");
        }
    }
}
