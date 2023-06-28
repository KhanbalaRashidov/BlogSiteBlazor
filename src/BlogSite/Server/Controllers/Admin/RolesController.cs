using BlogSite.Entities;
using BlogSite.Server.Controllers.Base;
using BlogSite.Shared.Dtos;
using BlogSite.Shared.Identity.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Server.Controllers.Admin
{
    public class RolesController : AdminControllerBase
    {
        private readonly RoleManager<Role> _roleManager;


        public RolesController(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public ActionResult ListRoles()
        {
            return Ok(_roleManager.Roles);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(RoleDTO roleDto)
        {
            if (string.IsNullOrWhiteSpace(roleDto.Name))
            {
                return BadRequest("Role name should be provided.");
            }
            await _roleManager.CreateAsync(new Role(roleDto.Name));

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditRole(RoleDTO roleDto)
        {
            var role = await _roleManager.FindByIdAsync(roleDto.Id);
            if (role == null) return NotFound();

            role.Name = roleDto.Name;

            await _roleManager.UpdateAsync(role);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRole(Guid id)
        {
            var identityRole = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);

            if (identityRole == null)
            {
                return NotFound();
            }

            if (identityRole.Name == Policies.IsAdmin)
            {
                return BadRequest();
            }

            await _roleManager.DeleteAsync(identityRole);

            return Ok();
        }
    }
}
