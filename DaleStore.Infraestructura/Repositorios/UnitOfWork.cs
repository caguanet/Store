using DaleStore.Core.Interfaces;
using DaleStore.Core.Interfaces.Repositorios;
using DaleStore.Infraestructura.Data;
using System;
using System.Threading.Tasks;

namespace DaleStore.Infraestructura.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DaleStoreContext _context;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly IVentaRepositorio _ventaRepositorio;

        public UnitOfWork(DaleStoreContext context)
        {
            _context = context;
        }
        public IClienteRepositorio ClienteRepositorio =>  _clienteRepositorio ??  new ClienteRepositorio(_context);

        public IProductoRepositorio ProductoRepositorio => _productoRepositorio ?? new ProductoRepositorio(_context);

        public IVentaRepositorio VentaRepositorio => _ventaRepositorio ?? new VentaRepositorio(_context);


        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
