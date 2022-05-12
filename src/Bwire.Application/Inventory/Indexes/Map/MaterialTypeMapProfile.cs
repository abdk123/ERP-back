using AutoMapper;
using Bwire.Inventory.Indexes.Dto;

namespace Bwire.Inventory.Indexes.Map
{
   public class MaterialTypeMapProfile : Profile
    {
        public MaterialTypeMapProfile()
        {
            CreateMap<MaterialType, MaterialTypeDto>();
            CreateMap<MaterialType, ReadMaterialTypeDto>();
            CreateMap<CreateMaterialTypeDto, MaterialType>();
            CreateMap<UpdateMaterialTypeDto, MaterialType>();
        }
    }
}

