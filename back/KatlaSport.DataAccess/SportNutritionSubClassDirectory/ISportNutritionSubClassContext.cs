namespace KatlaSport.DataAccess.SportNutritionSubClassDirectory
{
    public interface ISportNutritionSubClassContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="SportNutritionSubClass"/> entities.
        /// </summary>
        IEntitySet<SportNutritionSubClass> SportNutritionSubClasses { get; }
    }
}
