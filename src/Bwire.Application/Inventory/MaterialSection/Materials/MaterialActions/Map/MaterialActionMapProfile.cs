using AutoMapper;
using Bwire.Inventory.MaterialSection.Materials.MaterialActions.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.MaterialActions.Map
{
   public class MaterialActionMapProfile : Profile
    {
        public MaterialActionMapProfile()
        {
            CreateMap<MaterialAction, MaterialActionDto>();
            CreateMap<MaterialAction, ReadMaterialActionDto>();
            CreateMap<CreateMaterialActionDto, MaterialAction>();
            CreateMap<UpdateMaterialActionDto, MaterialAction>();
        }
    }
}

