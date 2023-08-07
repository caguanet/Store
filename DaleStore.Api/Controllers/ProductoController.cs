using AutoMapper;
using DaleStore.Core.DTOs.Producto;
using DaleStore.Core.Entidades;
using DaleStore.Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaleStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _ProductoServicio;
        private readonly IMapper _mapper;

        public ProductoController(IProductoServicio ProductoServicio, IMapper mapper)
        {
            _ProductoServicio = ProductoServicio;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var lstProductos = await _ProductoServicio.GetProductos();
            var lstProductosDto = _mapper.Map<IEnumerable<ProductoDto>>(lstProductos);

            var response = new ApiResponse<IEnumerable<ProductoDto>>(lstProductosDto);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var objProducto = await _ProductoServicio.GetProductoxId(id);
            var objProductosDto = _mapper.Map<ProductoDto>(objProducto);

            var response = new ApiResponse<ProductoDto>(objProductosDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoInsertarDto ProductoInsertarDto)
        {

            var objProducto = _mapper.Map<Producto>(ProductoInsertarDto);
            objProducto = await _ProductoServicio.InsertProducto(objProducto);

            var objProductoDto = _mapper.Map<ProductoDto>(objProducto);
            var response = new ApiResponse<ProductoDto>(objProductoDto);
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductoInsertarDto productoInsertarDto)
        {

            var objProducto = _mapper.Map<Producto>(productoInsertarDto);
            objProducto.Id = id;

            var resultado = await _ProductoServicio.UpdateProducto(objProducto);
            var response = new ApiResponse<bool>(resultado);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _ProductoServicio.DeleteProducto(id);
            var response = new ApiResponse<bool>(resultado);
            return Ok(response);
        }

    }
}
