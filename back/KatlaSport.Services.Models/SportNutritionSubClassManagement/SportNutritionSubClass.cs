namespace KatlaSport.Services.SportNutritionSubClassManagement
{
    public class SportNutritionSubClass
    {
        /// <summary>
        /// Gets or sets a SubClassName ID.
        /// </summary>
        public int SportNutritionSubClassID { get; set; }

        /// <summary>
        /// Gets or sets a SportNutritionClassID.
        /// </summary>
        public int SportNutritionClassID { get; set; }

        /// <summary>
        /// Gets or sets a SubClassName.
        /// </summary>
        public string SubClassName { get; set; }

        /// <summary>
        /// Gets or sets a Protein.
        /// </summary>
        public int Protein { get; set; }

        /// <summary>
        /// Gets or sets a Fat.
        /// </summary>
        public int Fat { get; set; }

        /// <summary>
        /// Gets or sets a Carbohydrate.
        /// </summary>
        public int Carbohydrate { get; set; }

        public byte[] Image { get; set; }
    }
}
