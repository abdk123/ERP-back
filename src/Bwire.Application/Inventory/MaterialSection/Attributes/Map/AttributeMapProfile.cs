using AutoMapper;
using Bwire.Inventory.MaterialSection.Attributes.Dto;

namespace Bwire.Inventory.MaterialSection.Attributes.Map
{
   public class AttributeMapProfile : Profile
    {
        public AttributeMapProfile()
        {
            CreateMap<Attribute, AttributeDto>();
            CreateMap<Attribute, ReadAttributeDto>();
            CreateMap<CreateAttributeDto, Attribute>();
            CreateMap<UpdateAttributeDto, Attribute>();
        }
    }
}

