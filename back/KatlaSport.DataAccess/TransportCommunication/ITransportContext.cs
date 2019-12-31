namespace KatlaSport.DataAccess.TransportCommunication
{
    public interface ITransportContext : IAsyncEntityStorage
    {
        IEntitySet<Transport> Transports { get; }

        IEntitySet<Information> Informations { get; }

        IEntitySet<Mode> Modes { get; }
    }
}
