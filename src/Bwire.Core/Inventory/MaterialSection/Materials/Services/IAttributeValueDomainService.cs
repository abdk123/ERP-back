using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public interface IAttributeValueDomainService : IDomainService
     {
        IQueryable<AttributeValue> Get();
        Task<IList<AttributeValue>> GetAllAsync();
        Task<AttributeValue> GetByIdAsync(long id);
        Task<AttributeValue> CreateAsync(AttributeValue attributeValue);
        Task<AttributeValue> UpdateAsync(AttributeValue attributeValue);
        Task DeleteAsync(long id);
    }
}

