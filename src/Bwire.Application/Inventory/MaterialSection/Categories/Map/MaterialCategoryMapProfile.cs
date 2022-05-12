using AutoMapper;
using Bwire.Inventory.MaterialSection.Categories.Dto;

namespace Bwire.Inventory.MaterialSection.Categories.Map
{
   public class MaterialCategoryMapProfile : Profile
    {
        public MaterialCategoryMapProfile()
        {
            CreateMap<MaterialCategory, MaterialCategoryDto>();
            CreateMap<MaterialCategory, ReadMaterialCategoryDto>();
            CreateMap<CreateMaterialCategoryDto, MaterialCategory>();
            CreateMap<UpdateMaterialCategoryDto, MaterialCategory>();
        }
    }
}

