using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Attributes.Services
{
    public interface IAttributeDomainService : IDomainService
     {
        IQueryable<Attribute> Get();
        Task<IList<Attribute>> GetAllAsync();
        Task<Attribute> GetByIdAsync(long id);
        Task<Attribute> CreateAsync(Attribute attribute);
        Task<Attribute> UpdateAsync(Attribute attribute);
        Task DeleteAsync(long id);
    }
}

