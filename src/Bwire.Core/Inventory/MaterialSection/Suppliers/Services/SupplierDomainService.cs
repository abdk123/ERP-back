using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Suppliers.Services
{
    public class SupplierDomainService : ISupplierDomainService
    {
        private readonly IRepository<Supplier, long> _supplierRepository;
        public SupplierDomainService(IRepository<Supplier, long> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public IQueryable<Supplier> Get()
        {
            return _supplierRepository.GetAll();
        }
        public async Task<IList<Supplier>> GetAllAsync()
        {
            return await _supplierRepository.GetAllListAsync();
        }
        public async Task<Supplier> GetByIdAsync(long id)
        {
            return await _supplierRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Supplier> CreateAsync(Supplier supplier)
        {
            return await _supplierRepository.InsertAsync(supplier);
        }
        public async Task<Supplier> UpdateAsync(Supplier supplier)
        {
            return await _supplierRepository.InsertOrUpdateAsync(supplier);
        }
        public async Task DeleteAsync(long id)
        {
            var supplier = await _supplierRepository.FirstOrDefaultAsync(id);
            await _supplierRepository.DeleteAsync(supplier);
        }
    }
}

