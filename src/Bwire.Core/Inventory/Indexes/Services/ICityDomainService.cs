using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.Indexes.Services
{
    public interface ICityDomainService : IDomainService
     {
        IQueryable<City> Get();
        Task<IList<City>> GetAllAsync();
        Task<City> GetByIdAsync(long id);
        Task<City> CreateAsync(City city);
        Task<City> UpdateAsync(City city);
        Task DeleteAsync(long id);
    }
}

