using DaleStore.Core.Entidades;
using System.Threading.Tasks;

namespace DaleStore.Core.Interfaces.Repositorios
{
    public interface IVentaRepositorio
    {
        Task<Venta> GetIncClientexId(int id);    
        Task<Venta> Add(Venta venta);

    }
}
