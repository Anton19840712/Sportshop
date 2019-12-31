namespace KatlaSport.Services.SportNutritionProductImageManagement
{
    public class SportNutritionProductImage
    {
        /// <summary>
        /// Gets or sets a ProductImage ID.
        /// </summary>
        public int SportNutritionProductImageID { get; set; }

        /// <summary>
        /// Gets or sets a ImageName.
        /// </summary>
        public string SportNutritionProductImageName { get; set; }

        public string SportNutritionProductImageTitle { get; set; }

        public byte[] SportNutritionProductImageData { get; set; }
    }
}
