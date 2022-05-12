using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Attributes.Services
{
    public class AttributeOptionDomainService : IAttributeOptionDomainService
    {
        private readonly IRepository<AttributeOption, long> _attributeOptionRepository;
        public AttributeOptionDomainService(IRepository<AttributeOption, long> attributeOptionRepository)
        {
            _attributeOptionRepository = attributeOptionRepository;
        }
        public IQueryable<AttributeOption> Get()
        {
            return _attributeOptionRepository.GetAll();
        }
        public async Task<IList<AttributeOption>> GetAllAsync()
        {
            return await _attributeOptionRepository.GetAllListAsync();
        }
        public async Task<AttributeOption> GetByIdAsync(long id)
        {
            return await _attributeOptionRepository.FirstOrDefaultAsync(id);
        }
        public async Task<AttributeOption> CreateAsync(AttributeOption attributeOption)
        {
            return await _attributeOptionRepository.InsertAsync(attributeOption);
        }
        public async Task<AttributeOption> UpdateAsync(AttributeOption attributeOption)
        {
            return await _attributeOptionRepository.InsertOrUpdateAsync(attributeOption);
        }
        public async Task DeleteAsync(long id)
        {
            var attributeOption = await _attributeOptionRepository.FirstOrDefaultAsync(id);
            await _attributeOptionRepository.DeleteAsync(attributeOption);
        }
    }
}

