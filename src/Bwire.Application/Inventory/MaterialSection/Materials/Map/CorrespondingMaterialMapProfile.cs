using AutoMapper;
using Bwire.Inventory.MaterialSection.Materials.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Map
{
   public class CorrespondingMaterialMapProfile : Profile
    {
        public CorrespondingMaterialMapProfile()
        {
            CreateMap<CorrespondingMaterial, CorrespondingMaterialDto>();
            CreateMap<CorrespondingMaterial, ReadCorrespondingMaterialDto>();
            CreateMap<CreateCorrespondingMaterialDto, CorrespondingMaterial>();
            CreateMap<UpdateCorrespondingMaterialDto, CorrespondingMaterial>();
        }
    }
}

