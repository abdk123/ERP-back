using AutoMapper;
using Bwire.Inventory.WarehouseSection.Categories.Dto;

namespace Bwire.Inventory.WarehouseSection.Categories.Map
{
   public class WarehouseCategoryMapProfile : Profile
    {
        public WarehouseCategoryMapProfile()
        {
            CreateMap<WarehouseCategory, WarehouseCategoryDto>();
            CreateMap<WarehouseCategory, ReadWarehouseCategoryDto>();
            CreateMap<CreateWarehouseCategoryDto, WarehouseCategory>();
            CreateMap<UpdateWarehouseCategoryDto, WarehouseCategory>();
        }
    }
}

