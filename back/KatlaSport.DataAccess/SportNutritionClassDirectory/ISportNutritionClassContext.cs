namespace KatlaSport.DataAccess.SportNutritionClassDirectory
{
    public interface ISportNutritionClassContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="SportNutritionClass"/> entities.
        /// </summary>
        IEntitySet<SportNutritionClass> SportNutritionClasses { get; }
    }
}