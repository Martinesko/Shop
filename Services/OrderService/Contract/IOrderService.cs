using Shop.Models.Order;
using Shop.Models.Product;

namespace Shop.Services.OrderService.Contract
{
    public interface IOrderService
    {
        Task<OrderViewModel> GetOrderAdressAsync(Guid Id);
    }
}
