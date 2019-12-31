using System.Collections.Generic;
using KatlaSport.DataAccess.SportNutritionSubClassDirectory;

namespace KatlaSport.DataAccess.SportNutritionClassDirectory
{
    public class SportNutritionClass
    {
        /// <summary>
        /// Gets or sets a ClassName ID.
        /// </summary>
        public int SportNutritionClassID { get; set; }

        /// <summary>
        /// Gets or sets a ClassName.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets one to many conntection
        /// </summary>
        public ICollection<SportNutritionSubClass> SportNutritionSubClasses { get; set; }
    }
}
