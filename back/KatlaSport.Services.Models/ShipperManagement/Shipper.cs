namespace KatlaSport.Services.ShipperManagement
{
    public class Shipper
    {
        public int ShipperID { get; set; }

        public string ShipperName { get; set; }

        public string ShipperPhone { get; set; }

        public int? ShipperCoordinatorID { get; set; }

        public int SportNutritionOrderID { get; set; }
    }
}
