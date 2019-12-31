namespace KatlaSport.DataAccess.ShipperDirectory
{
    internal sealed class ShipperContext : DomainContextBase<ApplicationDbContext>, IShipperContext
    {
        public ShipperContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<Shipper> Shippers => GetDbSet<Shipper>();
    }
}