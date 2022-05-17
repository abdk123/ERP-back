using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Bwire.Roles.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);
        List<RoleDto> GetAllRoles();
        Task<ReadGrudDto> GetForGrid([FromBody] DataManagerRequest dm);

    }
}
