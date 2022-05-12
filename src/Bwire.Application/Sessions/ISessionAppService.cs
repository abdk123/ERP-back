using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Sessions.Dto;

namespace Bwire.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
