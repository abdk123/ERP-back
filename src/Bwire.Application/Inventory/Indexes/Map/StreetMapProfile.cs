using AutoMapper;
using Bwire.Inventory.Indexes.Dto;

namespace Bwire.Inventory.Indexes.Map
{
   public class StreetMapProfile : Profile
    {
        public StreetMapProfile()
        {
            CreateMap<Street, StreetDto>();
            CreateMap<Street, ReadStreetDto>();
            CreateMap<CreateStreetDto, Street>();
            CreateMap<UpdateStreetDto, Street>();
        }
    }
}

