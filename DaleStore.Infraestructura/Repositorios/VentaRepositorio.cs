using DaleStore.Core.Entidades;
using DaleStore.Core.Interfaces.Repositorios;
using DaleStore.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaleStore.Infraestructura.Repositorios
{
    public class VentaRepositorio : BaseRepositorio<Venta>, IVentaRepositorio
    {
        public VentaRepositorio(DaleStoreContext context) : base(context) { }

        public async Task<Venta> Add(Venta venta)
        {
             await _entities.AddAsync(venta);
            return venta;
        }

        public async Task<Venta> GetIncClientexId(int id)
        {
            var obj = await _entities.Include(i=> i.IdClienteNavigation).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return obj;
        }
    }
}
