using AutoMapper;
using Bwire.Inventory.Indexes.Dto;

namespace Bwire.Inventory.Indexes.Map
{
   public class CityMapProfile : Profile
    {
        public CityMapProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<City, ReadCityDto>();
            CreateMap<CreateCityDto, City>();
            CreateMap<UpdateCityDto, City>();
        }
    }
}

