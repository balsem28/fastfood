using fastfood.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fastfood.Repository
{
    internal class DbInitializer:IDbInitialize

    {
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbcontext _context;
    public DbInitializer (RoleManager <IdentityRole> roleManager ,
        UserManager<IdentityUser> userManager ,
        ApplicationDbcontext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
    public void Initialize()
          {
            try
            {
                if (_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (_context.Roles.Any(x => x.Name == "Admin")) return;
            _roleManager.CreateAsync(new IdentityRole("Manager")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();

            var user = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "Admin",
                City = "Xyz",
                Address = "Xyz",
                PostalCode = "33333"
            };
            _userManager.CreateAsync(user,"Admin@123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user, "Admin");

        }

    }
    }




