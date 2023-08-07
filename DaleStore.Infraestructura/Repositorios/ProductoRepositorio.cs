using DaleStore.Core.Entidades;
using DaleStore.Core.Interfaces.Repositorios;
using DaleStore.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaleStore.Infraestructura.Repositorios
{
    class ProductoRepositorio : BaseRepositorio<Producto>, IProductoRepositorio
    {
        public ProductoRepositorio(DaleStoreContext context) : base(context) { }
        public async Task<Producto> Add(Producto producto)
        {
            await _entities.AddAsync(producto);
            return producto;
        }

        public async Task<bool> Delete(int id)
        {
            var objProducto = await GetxId(id);
            _entities.Remove(objProducto);

            return true;
        }

        public async Task<IEnumerable<Producto>> Get()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalVendidosxId(int id)
        {
            var obj = await _entities.AsNoTracking().Include(i=> i.VentaDetalle).FirstOrDefaultAsync(c => c.Id == id);
            return obj.VentaDetalle.Count();
        }

        public async Task<Producto> GetxId(int id)
        {
            var obj = await _entities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return obj;
        }

        public bool Update(Producto producto)
        {
            _entities.Update(producto);

            return true;
        }


    }
}
