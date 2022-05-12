using AutoMapper;
using Bwire.Inventory.WarehouseSection.Places.Dto;

namespace Bwire.Inventory.WarehouseSection.Places.Map
{
   public class PlaceMapProfile : Profile
    {
        public PlaceMapProfile()
        {
            CreateMap<Place, PlaceDto>();
            CreateMap<Place, ReadPlaceDto>();
            CreateMap<CreatePlaceDto, Place>();
            CreateMap<UpdatePlaceDto, Place>();
        }
    }
}

