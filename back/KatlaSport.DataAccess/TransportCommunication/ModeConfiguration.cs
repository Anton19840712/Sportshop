using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.TransportCommunication
{
    internal sealed class ModeConfiguration : EntityTypeConfiguration<Mode>
    {
        public ModeConfiguration()
        {
            ToTable("mode");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("mode_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Type).HasColumnName("mode_type").IsRequired();
        }
    }
}
