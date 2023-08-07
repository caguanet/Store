using AutoMapper;
using DaleStore.Core.DTOs.Venta;
using DaleStore.Core.Entidades;
using DaleStore.Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DaleStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaServicio _ventaServicio;
        private readonly IMapper _mapper;

        public VentaController(IVentaServicio ventaServicio, IMapper mapper)
        {
            _ventaServicio = ventaServicio;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(VentaInsertarDto ventaInsertarDto)
        {

            var objVenta= _mapper.Map<Venta>(ventaInsertarDto);
            objVenta = await _ventaServicio.InsertVenta(objVenta);

            var objVentaDto = _mapper.Map<VentaDto>(objVenta);
            var response = new ApiResponse<VentaDto>(objVentaDto);
            return Ok(response);
        }


    }
}
