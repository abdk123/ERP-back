using AutoMapper;
using Bwire.Inventory.RequestSection.MaterialRequests.Dto;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Map
{
   public class MaterialRequestMapProfile : Profile
    {
        public MaterialRequestMapProfile()
        {
            CreateMap<MaterialRequest, MaterialRequestDto>();
            CreateMap<MaterialRequest, ReadMaterialRequestDto>();
            CreateMap<CreateMaterialRequestDto, MaterialRequest>();
            CreateMap<UpdateMaterialRequestDto, MaterialRequest>();
        }
    }
}

