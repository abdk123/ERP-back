using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.Indexes.Services
{
    public class UnitDomainService : IUnitDomainService
    {
        private readonly IRepository<Unit, long> _unitRepository;
        public UnitDomainService(IRepository<Unit, long> unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public IQueryable<Unit> Get()
        {
            return _unitRepository.GetAll();
        }
        public async Task<IList<Unit>> GetAllAsync()
        {
            return await _unitRepository.GetAllListAsync();
        }
        public async Task<Unit> GetByIdAsync(long id)
        {
            return await _unitRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Unit> CreateAsync(Unit unit)
        {
            return await _unitRepository.InsertAsync(unit);
        }
        public async Task<Unit> UpdateAsync(Unit unit)
        {
            return await _unitRepository.InsertOrUpdateAsync(unit);
        }
        public async Task DeleteAsync(long id)
        {
            var unit = await _unitRepository.FirstOrDefaultAsync(id);
            await _unitRepository.DeleteAsync(unit);
        }
    }
}

