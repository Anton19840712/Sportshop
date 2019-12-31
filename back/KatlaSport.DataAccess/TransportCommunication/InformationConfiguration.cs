using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.TransportCommunication
{
    public class InformationConfiguration : EntityTypeConfiguration<Information>
    {
        public InformationConfiguration()
        {
            ToTable("information");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("information_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.File).HasColumnName("file").IsRequired();
            Property(i => i.Name).HasColumnName("file_name").IsRequired();
        }
    }
}
