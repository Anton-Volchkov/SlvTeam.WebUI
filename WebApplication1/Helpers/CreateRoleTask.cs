using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SlvTeam.Domain.Entities;

namespace WebApplication1.Helpers
{
    public class CreateRolesTask
    {
        private readonly RoleManager<IdentityRole> _manager;
        private readonly UserManager<SlvTeamUser> _userManager;

        public CreateRolesTask(RoleManager<IdentityRole> manager, UserManager<SlvTeamUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        public async Task Execute()
        {
            const string roleName = "Admin";

            if(await _manager.RoleExistsAsync(roleName))
            {
                return;
            }

            var role = new IdentityRole(roleName);
            await _manager.CreateAsync(role);

            var user = await _userManager.FindByNameAsync("Kerli");
            await _userManager.AddToRoleAsync(user, "Admin");

        }
    }
}