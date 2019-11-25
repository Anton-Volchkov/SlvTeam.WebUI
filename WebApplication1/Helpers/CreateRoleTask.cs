using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Helpers
{
    public class CreateRolesTask
    {
        private readonly RoleManager<IdentityRole> _manager;
      

        public CreateRolesTask(RoleManager<IdentityRole> manager)
        {
            _manager = manager;
        }

        public async Task Execute()
        {
          
            const string roleName = "Admin";

            if (await _manager.RoleExistsAsync(roleName))
            {
                return;
            }

            var role = new IdentityRole(roleName);
            await _manager.CreateAsync(role);
        }
    }
}
