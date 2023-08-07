using DaleStore.Core.Entidades;
using System.Threading.Tasks;

namespace DaleStore.Core.Interfaces.Servicios
{
    public interface IVentaServicio
    {
        Task<Venta> InsertVenta(Venta venta);
    }
}
