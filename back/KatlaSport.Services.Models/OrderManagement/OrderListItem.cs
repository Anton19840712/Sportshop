using System;

namespace KatlaSport.Services.OrderManagement
{
    public class OrderListItem
    {
        public string CustomerName { get; set; }

        public string TransportName { get; set; }

        public string TransportMode { get; set; }

        public DateTime OrderAcceptanceDate { get; set; }

        public DateTime OrderDispatchDate { get; set; }
    }
}
