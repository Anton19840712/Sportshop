namespace KatlaSport.DataAccess.SportNutritionClientDirectory
{
    public interface ISportNutritionClientContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="SportNutritionClient"/> entities.
        /// </summary>
        IEntitySet<SportNutritionClient> SportNutritionClients { get; }
    }
}