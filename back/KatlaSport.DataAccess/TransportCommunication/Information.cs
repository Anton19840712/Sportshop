using System.Collections.Generic;

namespace KatlaSport.DataAccess.TransportCommunication
{
    public class Information
    {
        public int Id { get; set; }

        public byte[] File { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Transport> Transports { get; set; }
    }
}
