using AutoMapper;
using Bwire.Inventory.MaterialSection.Suppliers.Dto;

namespace Bwire.Inventory.MaterialSection.Suppliers.Map
{
   public class SupplierMapProfile : Profile
    {
        public SupplierMapProfile()
        {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<Supplier, ReadSupplierDto>();
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<UpdateSupplierDto, Supplier>();
        }
    }
}

