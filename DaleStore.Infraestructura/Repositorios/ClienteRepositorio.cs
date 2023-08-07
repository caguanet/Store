using DaleStore.Core.Entidades;
using DaleStore.Core.Interfaces.Repositorios;
using DaleStore.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaleStore.Infraestructura.Repositorios
{
    public class ClienteRepositorio : BaseRepositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(DaleStoreContext context) : base(context) { }
        public async Task<Cliente> Add(Cliente cliente)
        {
            await _entities.AddAsync(cliente);
            return cliente;
        }

        public async Task<bool> Delete(int id)
        {
            var objCliente = await GetxId(id);
            _entities.Remove(objCliente);

            return true;
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalComprasxId(int id)
        {
            var obj = await _entities.AsNoTracking().Include(i=> i.Venta).FirstOrDefaultAsync(c => c.Id == id);
            return obj.Venta.Count();
        }

        public async Task<Cliente> GetxCedula(string cedula)
        {
            var obj = await _entities.AsNoTracking().FirstOrDefaultAsync(c => c.Cedula == cedula);
            return obj;
        }

        public async Task<Cliente> GetxId(int id)
        {
            var obj = await _entities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return obj;
        }

        public bool Update(Cliente cliente)
        {
            _entities.Update(cliente);

            return true;
        }
    }
}
