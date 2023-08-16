using Microsoft.AspNetCore.Mvc;
using Shop.Models.Order;
using Shop.Models.Product;

namespace Shop.Services.OrderService.Contract
{
    public interface IOrderService
    {
        Task<InputOrderViewModel> GetOrderAdressAsync(Guid Id);
        Task MakeOrder(Guid Id,InputOrderViewModel model);

    }
}
