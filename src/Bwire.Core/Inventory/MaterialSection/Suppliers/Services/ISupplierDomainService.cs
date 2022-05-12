using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Suppliers.Services
{
    public interface ISupplierDomainService : IDomainService
     {
        IQueryable<Supplier> Get();
        Task<IList<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(long id);
        Task<Supplier> CreateAsync(Supplier supplier);
        Task<Supplier> UpdateAsync(Supplier supplier);
        Task DeleteAsync(long id);
    }
}

