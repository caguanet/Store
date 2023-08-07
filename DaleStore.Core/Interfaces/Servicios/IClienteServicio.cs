using DaleStore.Core.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaleStore.Core.Interfaces.Servicios
{
    public interface IClienteServicio
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetClientexId(int id);
        Task<Cliente> GetClientexCedula(string cedula);
        Task<Cliente> InsertCliente(Cliente producto);
        Task<bool> UpdateCliente(Cliente entity);
        Task<bool> DeleteCliente(int id);
       
    }
}
