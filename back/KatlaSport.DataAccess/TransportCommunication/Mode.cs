using System.Collections.Generic;

namespace KatlaSport.DataAccess.TransportCommunication
{
    public class Mode
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Transport> Transports { get; set; }
    }
}
