using DaleStore.Core.Entidades;
using DaleStore.Core.Excepciones;
using DaleStore.Core.Interfaces;
using DaleStore.Core.Interfaces.Servicios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaleStore.Core.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClienteServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteCliente(int id)
        {
            await ValidarPorId(id);
            var total = await _unitOfWork.ClienteRepositorio.GetTotalComprasxId(id);
            if (total>0)
                throw new NegocioException("No se puede eliminar ya que tiene registros asociados.");

            var respuesta = await _unitOfWork.ClienteRepositorio.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return respuesta;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _unitOfWork.ClienteRepositorio.Get();
        }

        public async Task<Cliente> GetClientexCedula(string cedula)
        {
            return await _unitOfWork.ClienteRepositorio.GetxCedula(cedula);
        }

        public async Task<Cliente> GetClientexId(int id)
        {
            return await _unitOfWork.ClienteRepositorio.GetxId(id);
        }

        public async Task<Cliente> InsertCliente(Cliente cliente)
        {
            Cliente objCliente = await _unitOfWork.ClienteRepositorio.GetxCedula(cliente.Cedula);
            if (objCliente != null)
            {
                throw new NegocioException("Ya existe un cliente con este número de cédula.");
            }

            await _unitOfWork.ClienteRepositorio.Add(cliente);
            await _unitOfWork.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            await ValidarPorId(cliente.Id);

            var respuesta = _unitOfWork.ClienteRepositorio.Update(cliente);
            await _unitOfWork.SaveChangesAsync();
            return respuesta;

        }


        private async Task ValidarPorId(int id)
        {

            var objProcducto = await _unitOfWork.ClienteRepositorio.GetxId(id);
            if (objProcducto == null)
                throw new NegocioException("El cliente no existe.");
        }

    }
}
