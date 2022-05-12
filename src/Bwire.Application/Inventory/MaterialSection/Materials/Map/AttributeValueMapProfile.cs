using AutoMapper;
using Bwire.Inventory.MaterialSection.Materials.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Map
{
   public class AttributeValueMapProfile : Profile
    {
        public AttributeValueMapProfile()
        {
            CreateMap<AttributeValue, AttributeValueDto>();
            CreateMap<AttributeValue, ReadAttributeValueDto>();
            CreateMap<CreateAttributeValueDto, AttributeValue>();
            CreateMap<UpdateAttributeValueDto, AttributeValue>();
        }
    }
}

