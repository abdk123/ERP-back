using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Attributes.Services
{
    public interface IAttributeOptionDomainService : IDomainService
     {
        IQueryable<AttributeOption> Get();
        Task<IList<AttributeOption>> GetAllAsync();
        Task<AttributeOption> GetByIdAsync(long id);
        Task<AttributeOption> CreateAsync(AttributeOption attributeOption);
        Task<AttributeOption> UpdateAsync(AttributeOption attributeOption);
        Task DeleteAsync(long id);
    }
}

