using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.Indexes.Services
{
    public class AreaDomainService : IAreaDomainService
    {
        private readonly IRepository<Area, long> _areaRepository;
        public AreaDomainService(IRepository<Area, long> areaRepository)
        {
            _areaRepository = areaRepository;
        }
        public IQueryable<Area> Get()
        {
            return _areaRepository.GetAll();
        }
        public async Task<IList<Area>> GetAllAsync()
        {
            return await _areaRepository.GetAllListAsync();
        }
        public async Task<Area> GetByIdAsync(long id)
        {
            return await _areaRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Area> CreateAsync(Area area)
        {
            return await _areaRepository.InsertAsync(area);
        }
        public async Task<Area> UpdateAsync(Area area)
        {
            return await _areaRepository.InsertOrUpdateAsync(area);
        }
        public async Task DeleteAsync(long id)
        {
            var area = await _areaRepository.FirstOrDefaultAsync(id);
            await _areaRepository.DeleteAsync(area);
        }
    }
}

