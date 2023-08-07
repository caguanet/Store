using AutoMapper;
using DaleStore.Core.DTOs.Cliente;
using DaleStore.Core.Entidades;
using DaleStore.Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaleStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServicio _clienteServicio;
        private readonly IMapper _mapper;

        public ClienteController(IClienteServicio clienteServicio, IMapper mapper)
        {
            _clienteServicio = clienteServicio;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var lstClientes = await _clienteServicio.GetClientes();
            var lstClientesDto = _mapper.Map<IEnumerable<ClienteDto>>(lstClientes);

            var response = new ApiResponse<IEnumerable<ClienteDto>>(lstClientesDto);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var objCliente = await _clienteServicio.GetClientexId(id);
            var objClientesDto = _mapper.Map<ClienteDto>(objCliente);

            var response = new ApiResponse<ClienteDto>(objClientesDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteInsertarDto clienteInsertarDto)
        {

            var objCliente = _mapper.Map<Cliente>(clienteInsertarDto);
            objCliente = await _clienteServicio.InsertCliente(objCliente);

            var objClienteDto = _mapper.Map<ClienteDto>(objCliente);
            var response = new ApiResponse<ClienteDto>(objClienteDto);
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClienteInsertarDto clienteInsertarDto)
        {

            var objCliente = _mapper.Map<Cliente>(clienteInsertarDto);
            objCliente.Id = id;

            var resultado = await _clienteServicio.UpdateCliente(objCliente);
            var response = new ApiResponse<bool>(resultado);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _clienteServicio.DeleteCliente(id);
            var response = new ApiResponse<bool>(resultado);
            return Ok(response);
        }

    }
}
