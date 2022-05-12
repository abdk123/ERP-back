using AutoMapper;
using Bwire.Inventory.Indexes.Dto;

namespace Bwire.Inventory.Indexes.Map
{
   public class WarehouseTypeMapProfile : Profile
    {
        public WarehouseTypeMapProfile()
        {
            CreateMap<WarehouseType, WarehouseTypeDto>();
            CreateMap<WarehouseType, ReadWarehouseTypeDto>();
            CreateMap<CreateWarehouseTypeDto, WarehouseType>();
            CreateMap<UpdateWarehouseTypeDto, WarehouseType>();
        }
    }
}

