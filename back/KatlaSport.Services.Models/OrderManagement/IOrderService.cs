using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.OrderManagement
{
    public interface IOrderService
    {
        Task<List<OrderListItem>> GetOrdersAsync();

        Task<OrderListItem> GetOrderAsync(int orderId);

        Task<Order> AddOrderAsync(UpdateOrderRequest createRequest);

        Task<Order> UpdateOrderAsync(int orderId, UpdateOrderRequest updateRequest);

        Task RemoveOrderAsync(Order order);
    }
}
