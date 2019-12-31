namespace KatlaSport.DataAccess.OrderCommunication
{
    public interface IOrderContext : IAsyncEntityStorage
    {
        IEntitySet<Order> Orders { get; }

        IEntitySet<OrderProduct> OrderProducts { get; }
    }
}
