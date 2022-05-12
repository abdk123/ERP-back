using Abp.Application.Services;
using Bwire.MultiTenancy.Dto;

namespace Bwire.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

