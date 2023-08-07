using DaleStore.Core.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaleStore.Core.Interfaces.Servicios
{
    public interface IProductoServicio
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProductoxId(int id);
        Task<Producto> InsertProducto(Producto producto);
        Task<bool> UpdateProducto(Producto entity);
        Task<bool> DeleteProducto(int id);
    }
}
