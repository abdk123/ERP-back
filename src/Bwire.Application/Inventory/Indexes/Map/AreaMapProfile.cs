using AutoMapper;
using Bwire.Inventory.Indexes.Dto;

namespace Bwire.Inventory.Indexes.Map
{
   public class AreaMapProfile : Profile
    {
        public AreaMapProfile()
        {
            CreateMap<Area, AreaDto>();
            CreateMap<Area, ReadAreaDto>();
            CreateMap<CreateAreaDto, Area>();
            CreateMap<UpdateAreaDto, Area>();
        }
    }
}

