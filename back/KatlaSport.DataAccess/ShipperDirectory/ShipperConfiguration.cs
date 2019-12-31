using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ShipperDirectory
{
    internal sealed class ShipperConfiguration : EntityTypeConfiguration<Shipper>
    {
        public ShipperConfiguration()
        {
            ToTable("Shippers");
            HasKey(i => i.ShipperID);
            HasOptional(i => i.ShipperCoordinator).WithMany(i => i.Shippers).HasForeignKey(i => i.ShipperCoordinatorID);
        }
    }
}
