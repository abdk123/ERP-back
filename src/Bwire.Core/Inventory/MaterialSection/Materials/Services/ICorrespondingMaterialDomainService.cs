using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public interface ICorrespondingMaterialDomainService : IDomainService
     {
        IQueryable<CorrespondingMaterial> Get();
        Task<IList<CorrespondingMaterial>> GetAllAsync();
        Task<CorrespondingMaterial> GetByIdAsync(long id);
        Task<CorrespondingMaterial> CreateAsync(CorrespondingMaterial correspondingMaterial);
        Task<CorrespondingMaterial> UpdateAsync(CorrespondingMaterial correspondingMaterial);
        Task DeleteAsync(long id);
    }
}

