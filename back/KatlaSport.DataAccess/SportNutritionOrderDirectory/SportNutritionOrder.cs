using System;
using System.Collections.Generic;
using KatlaSport.DataAccess.ShipperDirectory;
using KatlaSport.DataAccess.SportNutritionClientDirectory;

namespace KatlaSport.DataAccess.SportNutritionOrderDirectory
{
    public class SportNutritionOrder
    {
        public int SportNutritionOrderID { get; set; }

        public int SportNutritionClientID { get; set; }

        public SportNutritionClient SportNutritionClient { get; set; }

        public int SportNutritionSubClassID { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public int ShipperID { get; set; }

        public ICollection<Shipper> Shipper { get; set; }
    }
}
