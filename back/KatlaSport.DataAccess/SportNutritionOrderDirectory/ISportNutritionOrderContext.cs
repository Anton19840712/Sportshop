namespace KatlaSport.DataAccess.SportNutritionOrderDirectory
{
    public interface ISportNutritionOrderContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="SportNutritionOrder"/> entities.
        /// </summary>
        IEntitySet<SportNutritionOrder> SportNutritionOrders { get; }
    }
}