using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Authorization.Accounts.Dto;

namespace Bwire.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
