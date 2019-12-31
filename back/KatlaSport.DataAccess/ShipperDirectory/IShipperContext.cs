namespace KatlaSport.DataAccess.ShipperDirectory
{
    public interface IShipperContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="OrderDetail"/> entities.
        /// </summary>
        IEntitySet<Shipper> Shippers { get; }
    }
}