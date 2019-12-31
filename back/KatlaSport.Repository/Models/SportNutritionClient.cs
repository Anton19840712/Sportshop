using System.Collections.Generic;

namespace KatlaSport.Repository.Models
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
        /// Gets or sets client's Gender.
        /// </summary>
        public string SportNutritionClientGender { get; set; }

        /// <summary>
        /// Gets or sets client's Age.
        /// </summary>
        public int SportNutritionClientAge { get; set; }

    }
}
