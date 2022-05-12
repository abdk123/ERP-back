using System.Threading.Tasks;
using Bwire.Configuration.Dto;

namespace Bwire.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
