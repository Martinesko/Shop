using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models.Shop;
using Shop.Models.Users;
using Shop.Services.UsersService.Contract;

namespace Shop.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly ShopDbContext dbContext;

        public UsersService(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<UsersViewModel>> GetAllUsersAsync()
        {
            var users = await dbContext.Users.Select(u => new UsersViewModel()
            {
                UserId = u.Id, 
                UserName = u.UserName,
                UserEmail = u.Email,
            }).ToListAsync();
            foreach (var user in users)
            {
                var userRoleId = dbContext.UserRoles.FirstOrDefault(ur => ur.UserId == user.UserId);

                if (userRoleId != null)
                {
                    var userRole = dbContext.Roles.FirstOrDefault(r=>r.Id == userRoleId.RoleId).Name;
                    user.Role = userRole;
                }
            }

            return users;
        }

        public async Task RemoveUserAsync(Guid userId)
        {
            dbContext.Users.Remove(dbContext.Users.FirstOrDefault(u => u.Id == userId));
            await dbContext.SaveChangesAsync();
        }
    }
}
