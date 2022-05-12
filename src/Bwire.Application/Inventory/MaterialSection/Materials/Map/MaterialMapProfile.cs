using AutoMapper;
using Bwire.Inventory.MaterialSection.Materials.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Map
{
   public class MaterialMapProfile : Profile
    {
        public MaterialMapProfile()
        {
            CreateMap<Material, MaterialDto>();
            CreateMap<Material, ReadMaterialDto>();
            CreateMap<CreateMaterialDto, Material>();
            CreateMap<UpdateMaterialDto, Material>();
        }
    }
}

