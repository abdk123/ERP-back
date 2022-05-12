using AutoMapper;
using Bwire.Inventory.MaterialSection.Materials.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Map
{
   public class MaterialQuantityMapProfile : Profile
    {
        public MaterialQuantityMapProfile()
        {
            CreateMap<MaterialQuantity, MaterialQuantityDto>();
            CreateMap<MaterialQuantity, ReadMaterialQuantityDto>();
            CreateMap<CreateMaterialQuantityDto, MaterialQuantity>();
            CreateMap<UpdateMaterialQuantityDto, MaterialQuantity>();
        }
    }
}

