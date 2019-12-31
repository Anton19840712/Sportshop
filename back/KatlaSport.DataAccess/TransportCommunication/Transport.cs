using System.Collections.Generic;
using KatlaSport.DataAccess.OrderCommunication;

namespace KatlaSport.DataAccess.TransportCommunication
{
    public class Transport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ModeId { get; set; }

        public virtual Mode Mode { get; set; }

        public int? CoordinatorId { get; set; }

        public virtual Transport Coordinator { get; set; }

        public int InformationId { get; set; }

        public virtual Information Information { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Transport> Transports { get; set; }
    }
}
