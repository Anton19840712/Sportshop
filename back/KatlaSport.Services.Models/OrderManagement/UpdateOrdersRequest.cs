using System;

namespace KatlaSport.Services.OrderManagement
{
    public class UpdateOrdersRequest
    {
        public int CustomerId { get; set; }

        public int TransportId { get; set; }

        public DateTime OrderAcceptanceDate { get; set; }

        public DateTime OrderDispatchDate { get; set; }

        public int OrderProductsId { get; set; }
    }
}
