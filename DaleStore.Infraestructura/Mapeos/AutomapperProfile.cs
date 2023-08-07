using AutoMapper;
using DaleStore.Core.DTOs.Cliente;
using DaleStore.Core.DTOs.Producto;
using DaleStore.Core.DTOs.Venta;
using DaleStore.Core.DTOs.VentaDetalle;
using DaleStore.Core.Entidades;

namespace DaleStore.Infraestructura.Mapeos
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap(); 
            CreateMap<ClienteInsertarDto, Cliente>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<ProductoInsertarDto, Producto>().ReverseMap();
            CreateMap< Venta, VentaDto>().ForMember(dto=>  dto.NombreCliente,conf => conf.MapFrom(vt=> vt.IdClienteNavigation.Nombre)) .ReverseMap();
            CreateMap<VentaInsertarDto, Venta>().ReverseMap();
            CreateMap<VentaDetalleInsertarDto, VentaDetalle>().ReverseMap();
        }


    }
}
