using System.Collections.Generic;
using KatlaSport.DataAccess.SportNutritionClassDirectory;
using KatlaSport.DataAccess.SportNutritionProductImageDirectory;

namespace KatlaSport.DataAccess.SportNutritionSubClassDirectory
{
    public class SportNutritionSubClass
    {
        /// <summary>
        /// Gets or sets a SubClassName ID.
        /// </summary>
        public int SportNutritionSubClassID { get; set; }

        /// <summary>
        /// Gets or sets a SubClassName.
        /// </summary>
        public string SubClassName { get; set; }

        /// <summary>
        /// Gets or sets a SportNutritionClass.
        /// </summary>
        public SportNutritionClass SportNutritionClass { get; set; }

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

        /// <summary>
        /// Gets or sets a SportNutritionClassID.
        /// </summary>
        public int SportNutritionClassID { get; set; }

        /// <summary>
        /// Gets or sets a ProductImage.
        /// </summary>
        public ICollection<SportNutritionProductImage> SportNutritionProductImages { get; set; }
    }
}
