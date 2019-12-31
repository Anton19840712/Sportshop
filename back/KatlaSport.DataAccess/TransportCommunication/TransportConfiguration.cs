using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.TransportCommunication
{
    public class TransportConfiguration : EntityTypeConfiguration<Transport>
    {
        public TransportConfiguration()
        {
            ToTable("transport");
            HasKey(i => i.Id);
            HasOptional(i => i.Coordinator).WithMany(i => i.Transports).HasForeignKey(i => i.CoordinatorId);
            HasRequired(i => i.Information).WithMany(i => i.Transports).HasForeignKey(i => i.InformationId);
            HasRequired(i => i.Mode).WithMany(i => i.Transports).HasForeignKey(i => i.ModeId);
            Property(i => i.Id).HasColumnName("transport_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("transport_name").HasMaxLength(200).IsRequired();
            Property(i => i.ModeId).HasColumnName("transport_mode_id").IsOptional();
            Property(i => i.CoordinatorId).HasColumnName("coordinator_transport_id").IsOptional();
            Property(i => i.InformationId).HasColumnName("transort_information_id").IsOptional();
        }
    }
}
