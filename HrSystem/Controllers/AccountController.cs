using HrSystem.Models;
using HrSystem.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        IAccountInterface account;

        public AccountController(IAccountInterface _account)
        {
            account = _account;
        }
    
        public IActionResult CrateAccount()
        {
            return View("CrateAccount");
        }
        
        public async Task<IActionResult> SingUpAccount(SingUpDto singUpDto)
        {
            //insert Account
             await account.SinUpAccount(singUpDto);

            return View("CrateAccount");
        }

        [AllowAnonymous]
        public IActionResult Sigin() 
        {

            return View("Sigin");
        }
        [AllowAnonymous]
        public async Task<IActionResult> CheckPassword(SignDto signDto)
        {
            var  result=await account.CheckPasswod(signDto);

            if (result.Succeeded)
            {
                return RedirectToAction("IndexSearchEmp", "Employee");
            }
            else 
            {
                ViewData["result"] = "Inaild UserName or Password";
                return View("Sigin");
            }
        }

        public IActionResult AddRoleUser()
        {
            return View("AddRoleUser");
        }

        public async Task<IActionResult> CrateRole(RoleDto roleDto)
        {
            await account.CrateRoleManger(roleDto);
            return View("AddRoleUser");
        }

        public async Task<IActionResult> UsersList()
        {
            List<UserDto> listeUserDto =await account.GetUsers();

            return View("UsersList", listeUserDto);
        }

        public async Task<IActionResult> GetUser(string id)
        {
            VmUsersanRole vm = new VmUsersanRole();

            vm.listroledto =await account.GetRoleMange(id);
            UserDto userDtoAll= await account.getUserByid(id);
           
            vm.userDto = userDtoAll;

            return View("UsersListWithRoleList",vm);
        }

        public async Task<IActionResult> Update(VmUsersanRole vm)
        {
            await account.Update(vm);
          
            return View("UsersListWithRoleList",vm);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await account.LogOut();

            return View("Sigin");
        }




    }
}
