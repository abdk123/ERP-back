using AutoMapper;
using Bwire.Inventory.RequestSection.MaterialRequests.Dto;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Map
{
   public class MaterialRequestDetailMapProfile : Profile
    {
        public MaterialRequestDetailMapProfile()
        {
            CreateMap<MaterialRequestDetail, MaterialRequestDetailDto>();
            CreateMap<MaterialRequestDetail, ReadMaterialRequestDetailDto>();
            CreateMap<CreateMaterialRequestDetailDto, MaterialRequestDetail>();
            CreateMap<UpdateMaterialRequestDetailDto, MaterialRequestDetail>();
        }
    }
}

