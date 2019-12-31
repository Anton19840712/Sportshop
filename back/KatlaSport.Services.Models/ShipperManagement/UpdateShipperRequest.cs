namespace KatlaSport.Services.ShipperManagement
{
    public class UpdateShipperRequest
    {
        public string ShipperName { get; set; }

        public string ShipperPhone { get; set; }

        public int? ShipperCoordinatorID { get; set; }

        public int SportNutritionOrderID { get; set; }
    }
}
