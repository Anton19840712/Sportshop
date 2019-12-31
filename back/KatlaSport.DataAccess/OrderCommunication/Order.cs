using System;
using System.Collections.Generic;
using KatlaSport.DataAccess.CustomerCatalogue;
using KatlaSport.DataAccess.TransportCommunication;

namespace KatlaSport.DataAccess.OrderCommunication
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int TransportId { get; set; }

        public virtual Transport Transport { get; set; }

        public DateTime OrderAcceptanceDate { get; set; }

        public DateTime OrderDispatchDate { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
