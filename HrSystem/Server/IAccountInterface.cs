using HrSystem.Data;
using HrSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace HrSystem.Server
{
    public interface IAccountInterface
    {

        Task<IdentityResult> SinUpAccount(SingUpDto singUpDto);

        Task<SignInResult> CheckPasswod(SignDto signDto);

        Task<IdentityResult> CrateRoleManger(RoleDto roleDto);

        Task<List<UserDto>> GetUsers();

        Task<List<RoleDto>> GetRoleMange(string id);

        Task<UserDto> getUserByid(string id);

        Task Update(VmUsersanRole vm);

         Task LogOut();

    }
}
