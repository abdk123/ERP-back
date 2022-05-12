using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public class AttributeValueDomainService : IAttributeValueDomainService
    {
        private readonly IRepository<AttributeValue, long> _attributeValueRepository;
        public AttributeValueDomainService(IRepository<AttributeValue, long> attributeValueRepository)
        {
            _attributeValueRepository = attributeValueRepository;
        }
        public IQueryable<AttributeValue> Get()
        {
            return _attributeValueRepository.GetAll();
        }
        public async Task<IList<AttributeValue>> GetAllAsync()
        {
            return await _attributeValueRepository.GetAllListAsync();
        }
        public async Task<AttributeValue> GetByIdAsync(long id)
        {
            return await _attributeValueRepository.FirstOrDefaultAsync(id);
        }
        public async Task<AttributeValue> CreateAsync(AttributeValue attributeValue)
        {
            return await _attributeValueRepository.InsertAsync(attributeValue);
        }
        public async Task<AttributeValue> UpdateAsync(AttributeValue attributeValue)
        {
            return await _attributeValueRepository.InsertOrUpdateAsync(attributeValue);
        }
        public async Task DeleteAsync(long id)
        {
            var attributeValue = await _attributeValueRepository.FirstOrDefaultAsync(id);
            await _attributeValueRepository.DeleteAsync(attributeValue);
        }
    }
}

