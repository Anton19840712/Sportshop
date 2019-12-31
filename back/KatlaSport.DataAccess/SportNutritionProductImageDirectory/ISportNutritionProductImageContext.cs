namespace KatlaSport.DataAccess.SportNutritionProductImageDirectory
{
    public interface ISportNutritionProductImageContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="SportNutritionProductImage"/> entities.
        /// </summary>
        IEntitySet<SportNutritionProductImage> SportNutritionProductImages { get; }
    }
}