using System.Collections.Generic;
using KatlaSport.DataAccess.SportNutritionOrderDirectory;

namespace KatlaSport.DataAccess.ShipperDirectory
{
    public class Shipper
    {
        public int ShipperID { get; set; }

        public string ShipperName { get; set; }

        public string ShipperPhone { get; set; }

        public int SportNutritionOrderID { get; set; }

        public SportNutritionOrder SportNutritionOrder { get; set; }

        public Shipper ShipperCoordinator { get; set; }

        public int? ShipperCoordinatorID { get; set; }

        public ICollection<Shipper> Shippers { get; set; }
    }
}
