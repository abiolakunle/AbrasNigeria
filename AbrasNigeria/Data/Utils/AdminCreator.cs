using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Data.Models;
using AbrasNigeria.Data.Services;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Utils
{
    public static class AdminCreator
    {


        public static void CreateSuperAdmin(IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {

                IUserService _userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                AppDbContext _dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                User user = new User
                {
                    UserName = "AbrasAdmin",
                    FirstName = "Abras",
                    LastName = "Nigeria",
                    Role = Roles.SuperAdmin,
                };

                bool exists = _dbContext.Users.Any(u => u.UserName == user.UserName);

                if (!exists)
                    _userService.CreateUser(user, "abrasAdmin");
            };
        }
    }
}
