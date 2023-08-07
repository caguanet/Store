using DaleStore.Core.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaleStore.Core.Interfaces.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<IEnumerable<Producto>> Get();
        Task<Producto> GetxId(int id);
        Task<int> GetTotalVendidosxId(int id);
        Task<Producto> Add(Producto producto);
        bool Update(Producto entity);
        Task<bool> Delete(int id);

    }
}
