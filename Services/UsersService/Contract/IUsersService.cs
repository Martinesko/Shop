using Microsoft.AspNetCore.Mvc;
using Shop.Models.Shop;
using Shop.Models.Users;

namespace Shop.Services.UsersService.Contract
{
    public interface IUsersService
    {
        public Task<IEnumerable<UsersViewModel>> GetAllUsersAsync();
        public Task RemoveUserAsync(Guid userId);
        public Task GrandAdminUserAsync(Guid userId);
    }
}
