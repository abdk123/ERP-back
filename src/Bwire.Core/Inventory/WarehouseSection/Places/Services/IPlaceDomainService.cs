using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;
using Bwire.Inventory.WarehouseSection.Places;

namespace Bwire.Inventory.WarehouseSection.Places.Services
{
    public interface IPlaceDomainService : IDomainService
    {
        IQueryable<Place> Get();
        Task<IList<Place>> GetAllAsync();
        Task<Place> GetByIdAsync(long id);
        Task<Place> CreateAsync(Place place);
        Task<Place> UpdateAsync(Place place);
        Task DeleteAsync(long id);
    }
}

