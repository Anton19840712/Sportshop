using System;
using System.Collections.Generic;

namespace KatlaSport.Services.OrderManagement
{
    public class UpdateOrderRequest
    {
        public int CustomerId { get; set; }

        public int TransportId { get; set; }

        public DateTime OrderAcceptanceDate { get; set; }

        public DateTime OrderDispatchDate { get; set; }

        public List<UpdateOrderProductRequest> OrderProducts { get; set; }
    }
}
