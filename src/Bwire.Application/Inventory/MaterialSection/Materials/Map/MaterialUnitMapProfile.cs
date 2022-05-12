using AutoMapper;
using Bwire.Inventory.MaterialSection.Materials.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Map
{
   public class MaterialUnitMapProfile : Profile
    {
        public MaterialUnitMapProfile()
        {
            CreateMap<MaterialUnit, MaterialUnitDto>();
            CreateMap<MaterialUnit, ReadMaterialUnitDto>();
            CreateMap<CreateMaterialUnitDto, MaterialUnit>();
            CreateMap<UpdateMaterialUnitDto, MaterialUnit>();
        }
    }
}

