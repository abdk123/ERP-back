using AutoMapper;
using Bwire.Inventory.MaterialSection.Attributes.Dto;

namespace Bwire.Inventory.MaterialSection.Attributes.Map
{
   public class AttributeOptionMapProfile : Profile
    {
        public AttributeOptionMapProfile()
        {
            CreateMap<AttributeOption, AttributeOptionDto>();
            CreateMap<AttributeOption, ReadAttributeOptionDto>();
            CreateMap<CreateAttributeOptionDto, AttributeOption>();
            CreateMap<UpdateAttributeOptionDto, AttributeOption>();
        }
    }
}

