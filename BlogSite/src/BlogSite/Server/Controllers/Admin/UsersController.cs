using BlogSite.Entities;
using BlogSite.Server.Controllers.Base;
using BlogSite.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Server.Controllers.Admin
{
    public class UsersController : AdminControllerBase
    {
        private readonly UserManager<User> _userManager;


        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> ListUsers()
        {
            var users = await _userManager.Users.Select(u => new UserDTO
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                UserRoles = u.UserRoles.Select(_ => _.Role.Name).ToList()
            }).AsNoTracking().ToListAsync();

            return Ok(users);
        }


        [HttpPut]
        public async Task<ActionResult> EditUser(UserUpdateDTO userModel)
        {
            var user = await _userManager.FindByIdAsync(userModel.Id);
            if (user == null) return NotFound("User not found.");
            var currentRole = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, currentRole);
            await _userManager.AddToRoleAsync(user, userModel.RoleName);

            user.UserName = userModel.UserName;
            user.Email = userModel.Email;


            await _userManager.UpdateAsync(user);

            return Ok();
        }
    }
}
