using DaleStore.Core.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaleStore.Core.Interfaces.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<IEnumerable<Cliente>> Get();
        Task<Cliente> GetxId(int id);
        Task<Cliente> GetxCedula(string cedula);
        Task<int> GetTotalComprasxId(int id);
        Task<Cliente> Add(Cliente cliente);
        bool Update(Cliente cliente);
        Task<bool> Delete(int id);
   
    }
}
