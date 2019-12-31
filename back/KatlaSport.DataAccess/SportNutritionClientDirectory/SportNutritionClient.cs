using System.Collections.Generic;
using KatlaSport.DataAccess.SportNutritionOrderDirectory;

namespace KatlaSport.DataAccess.SportNutritionClientDirectory
{
    public class SportNutritionClient
    {
        /// <summary>
        /// Gets or sets client's ID.
        /// </summary>
        public int SportNutritionClientID { get; set; }

        /// <summary>
        /// Gets or sets client's Name.
        /// </summary>
        public string SportNutritionClientName { get; set; }

        /// <summary>
        /// Gets or sets client's City.
        /// </summary>
        public string SportNutritionClientCity { get; set; }

        /// <summary>
        /// Gets or sets client's Male.
        /// </summary>
        public string SportNutritionClientGender { get; set; }

        /// <summary>
        /// Gets or sets client's Age.
        /// </summary>
        public int SportNutritionClientAge { get; set; }

        /// <summary>
        /// Gets or sets collection of client's orders.
        /// </summary>
        public ICollection<SportNutritionOrder> SportNutritionOrder { get; set; }
    }
}
