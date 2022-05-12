using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Attributes.Services
{
    public class AttributeDomainService : IAttributeDomainService
    {
        private readonly IRepository<Attribute, long> _attributeRepository;
        public AttributeDomainService(IRepository<Attribute, long> attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }
        public IQueryable<Attribute> Get()
        {
            return _attributeRepository.GetAll();
        }
        public async Task<IList<Attribute>> GetAllAsync()
        {
            return await _attributeRepository.GetAllListAsync();
        }
        public async Task<Attribute> GetByIdAsync(long id)
        {
            return await _attributeRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Attribute> CreateAsync(Attribute attribute)
        {
            return await _attributeRepository.InsertAsync(attribute);
        }
        public async Task<Attribute> UpdateAsync(Attribute attribute)
        {
            return await _attributeRepository.InsertOrUpdateAsync(attribute);
        }
        public async Task DeleteAsync(long id)
        {
            var attribute = await _attributeRepository.FirstOrDefaultAsync(id);
            await _attributeRepository.DeleteAsync(attribute);
        }
    }
}

