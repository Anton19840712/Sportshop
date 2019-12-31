using KatlaSport.DataAccess.SportNutritionSubClassDirectory;

namespace KatlaSport.DataAccess.SportNutritionProductImageDirectory
{
    public class SportNutritionProductImage
    {
        /// <summary>
        /// Gets or sets SportNutritionSubClass
        /// </summary>
        public SportNutritionSubClass SportNutritionSubClass { get; set; }

        /// <summary>
        /// Gets or sets a ProductImage ID.
        /// </summary>
        public int SportNutritionProductImageID { get; set; }

        /// <summary>
        /// Gets or sets a ImageName.
        /// </summary>
        public string SportNutritionProductImageName { get; set; }

        public string SportNutritionProductImageTitle { get; set; }

        /// <summary>
        /// Gets or sets a ImageName.
        /// </summary>
        public byte[] SportNutritionProductImageData { get; set; }
    }
}