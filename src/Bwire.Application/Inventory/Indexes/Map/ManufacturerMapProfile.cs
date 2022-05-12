using AutoMapper;
using Bwire.Inventory.Indexes.Dto;

namespace Bwire.Inventory.Indexes.Map
{
   public class ManufacturerMapProfile : Profile
    {
        public ManufacturerMapProfile()
        {
            CreateMap<Manufacturer, ManufacturerDto>();
            CreateMap<Manufacturer, ReadManufacturerDto>();
            CreateMap<CreateManufacturerDto, Manufacturer>();
            CreateMap<UpdateManufacturerDto, Manufacturer>();
        }
    }
}

