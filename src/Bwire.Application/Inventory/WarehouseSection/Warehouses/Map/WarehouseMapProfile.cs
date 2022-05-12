using AutoMapper;
using Bwire.Inventory.WarehouseSection.Warehouses.Dto;

namespace Bwire.Inventory.WarehouseSection.Warehouses.Map
{
   public class WarehouseMapProfile : Profile
    {
        public WarehouseMapProfile()
        {
            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<Warehouse, ReadWarehouseDto>();
            CreateMap<CreateWarehouseDto, Warehouse>();
            CreateMap<UpdateWarehouseDto, Warehouse>();
        }
    }
}

