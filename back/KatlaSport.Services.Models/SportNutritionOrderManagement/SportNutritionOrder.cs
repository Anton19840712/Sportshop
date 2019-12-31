using System;

namespace KatlaSport.Services.SportNutritionOrderManagement
{
    public class SportNutritionOrder
    {
        /// <summary>
        /// Gets or sets a SportNutritionElement ID.
        /// </summary>
        public int SportNutritionOrderID { get; set; }

        /// <summary>
        /// Gets or sets a SportNutritionClientID.
        /// </summary>
        public int SportNutritionClientID { get; set; }

        /// <summary>
        /// Gets or sets a SportNutritionSubClassID.
        /// </summary>
        public int SportNutritionSubClassID { get; set; }

        /// <summary>
        /// Gets or sets a Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets a Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a Total Price.
        /// </summary>
        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
