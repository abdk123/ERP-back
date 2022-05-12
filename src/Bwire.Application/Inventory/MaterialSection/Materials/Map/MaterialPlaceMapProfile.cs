using AutoMapper;
using Bwire.Inventory.MaterialSection.Materials.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Map
{
   public class MaterialPlaceMapProfile : Profile
    {
        public MaterialPlaceMapProfile()
        {
            CreateMap<MaterialPlace, MaterialPlaceDto>();
            CreateMap<MaterialPlace, ReadMaterialPlaceDto>();
            CreateMap<CreateMaterialPlaceDto, MaterialPlace>();
            CreateMap<UpdateMaterialPlaceDto, MaterialPlace>();
        }
    }
}

