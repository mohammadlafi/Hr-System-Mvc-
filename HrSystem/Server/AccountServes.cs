using AutoMapper;
using HrSystem.Data;
using HrSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace HrSystem.Server
{
    public class AccountServes : IAccountInterface
    {
        private readonly UserManager<ApplicationUser> userManager; 
        private readonly SignInManager<ApplicationUser> signInManager; 
        private readonly RoleManager<IdentityRole> roleManager; 
    
        public AccountServes(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager,RoleManager<IdentityRole> _roleManager)
        {
          userManager = _userManager;
          signInManager = _signInManager;
          roleManager=_roleManager;

        }

        public async Task<IdentityResult> SinUpAccount(SingUpDto singUpDto)
        {

            ApplicationUser user = new ApplicationUser();

            user.Email = singUpDto.Email;
            user.UserName = singUpDto.Email;
            user.PhoneNumber = singUpDto.Phone;
            user.Name = singUpDto.Name;

           var result=await userManager.CreateAsync(user, singUpDto.Password);

            return result;


        }

        public async Task<SignInResult> CheckPasswod(SignDto signDto)
        {
            var result=await signInManager.PasswordSignInAsync(signDto.Email,signDto.Password,signDto.Rememberme,false);

            return result;
            
        }

        public async Task<IdentityResult> CrateRoleManger(RoleDto roleDto)
        {
            IdentityRole identityRole = new IdentityRole();

            identityRole.Name = roleDto.Name;

           var result= await roleManager.CreateAsync(identityRole);

            return result;
        }

        public async Task<List<UserDto>> GetUsers() 
        {
            List<UserDto> listuserDtos = new List<UserDto>();

            List<ApplicationUser> applicationUser= await userManager.Users.ToListAsync();

            foreach (ApplicationUser item in applicationUser ) 
            {
                UserDto userDto = new UserDto();
                userDto.Name = item.UserName;
                userDto.id = item.Id;
                listuserDtos.Add(userDto);
            }

            return listuserDtos;
        }

        public async Task<List<RoleDto>> GetRoleMange(string id)
        {

            List<RoleDto> listroleDto = new List<RoleDto>();

           List<IdentityRole> role=await roleManager.Roles.ToListAsync();

            foreach (IdentityRole item in role)
            {
                RoleDto roleDto = new RoleDto();
                roleDto.Name = item.Name;
                roleDto.id = item.Id;
                listroleDto.Add(roleDto);
            }
            var user = await userManager.FindByIdAsync(id);
            var userroles = await userManager.GetRolesAsync(user);

            foreach (RoleDto item in listroleDto)
            {
               if (userroles.Contains(item.Name))
               {
                        item.IsSelcted = true;
               }
              
            }

            return listroleDto;
        }

        public async Task<UserDto> getUserByid(string id)
        {
            UserDto userDto = new UserDto();

            var users = await userManager.FindByIdAsync(id);
            userDto.Name = users.UserName;
            userDto.id = users.Id;

            return userDto;

        }

        public async Task Update(VmUsersanRole vm)
        {
            foreach(RoleDto item in vm.listroledto) 
            {
                ApplicationUser user = await userManager.FindByIdAsync(vm.userDto.id);
                if (item.IsSelcted == true)
                {
                    if (await userManager.IsInRoleAsync(user, item.Name) == false)
                    {
                        await userManager.AddToRoleAsync(user, item.Name);
                    }
                }
                else 
                {
                    if (await userManager.IsInRoleAsync(user, item.Name) == true) 
                    {
                        await userManager.RemoveFromRoleAsync(user, item.Name);
                    }
                                    
                }
            }  
        
        }

        public async Task LogOut()
        {
           await signInManager.SignOutAsync();
        }
        
    }
}
