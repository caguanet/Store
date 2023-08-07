using DaleStore.Core.Interfaces.Repositorios;
using System;
using System.Threading.Tasks;

namespace DaleStore.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepositorio ClienteRepositorio { get; }
        IProductoRepositorio ProductoRepositorio { get; }
        IVentaRepositorio VentaRepositorio { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
