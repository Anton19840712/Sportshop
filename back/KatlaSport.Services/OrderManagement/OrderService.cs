using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.OrderCommunication;
using DbOrder = KatlaSport.DataAccess.OrderCommunication.Order;

namespace KatlaSport.Services.OrderManagement
{
    public class OrderService : IOrderService
    {
        private readonly IOrderContext _context;

        public OrderService(IOrderContext context)
        {
            _context = context;
        }

        public async Task<List<OrderListItem>> GetOrdersAsync()
        {
            var dbOrders = await _context.Orders.OrderBy(s => s.Id).ToArrayAsync();
            var orders = dbOrders.Select(o => Mapper.Map<OrderListItem>(o)).ToList();
            return orders;
        }

        public async Task<OrderListItem> GetOrderAsync(int orderId)
        {
            var dbOrders = await _context.Orders.Where(h => h.Id == orderId).ToArrayAsync();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbOrder, OrderListItem>(dbOrders[0]);
        }

        public async Task<Order> AddOrderAsync(UpdateOrderRequest createRequest)
        {
            var dbOrder = Mapper.Map<UpdateOrderRequest, DbOrder>(createRequest);
            _context.Orders.Add(dbOrder);

            await _context.SaveChangesAsync();

            return Mapper.Map<Order>(dbOrder);
        }

        public async Task RemoveOrderAsync(Order order)
        {
            var dbOrders = await _context.Orders.Where(p => p.Id == order.Id).ToArrayAsync();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbOrder = dbOrders[0];

            _context.Orders.Remove(dbOrder);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> UpdateOrderAsync(int orderId, UpdateOrderRequest updateRequest)
        {
            var dbOrders = await _context.Orders.Where(h => h.Id == orderId).ToArrayAsync();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbOrder = dbOrders[0];
            Mapper.Map(updateRequest, dbOrder);

            await _context.SaveChangesAsync();
            return Mapper.Map<Order>(dbOrder);
        }
    }
}
