namespace KatlaSport.DataAccess.TransportCommunication
{
    internal sealed class TransportContext : DomainContextBase<ApplicationDbContext>, ITransportContext
    {
        public TransportContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<Transport> Transports => GetDbSet<Transport>();

        public IEntitySet<Information> Informations => GetDbSet<Information>();

        public IEntitySet<Mode> Modes => GetDbSet<Mode>();
    }
}