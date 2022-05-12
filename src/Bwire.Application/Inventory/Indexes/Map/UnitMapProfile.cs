using AutoMapper;
using Bwire.Inventory.Indexes.Dto;

namespace Bwire.Inventory.Indexes.Map
{
   public class UnitMapProfile : Profile
    {
        public UnitMapProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<Unit, ReadUnitDto>();
            CreateMap<CreateUnitDto, Unit>();
            CreateMap<UpdateUnitDto, Unit>();
        }
    }
}

