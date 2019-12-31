namespace KatlaSport.DataAccess.SportNutritionClientDirectory
{
    internal sealed class SportNutritionClientContext : DomainContextBase<ApplicationDbContext>, ISportNutritionClientContext
    {
        public SportNutritionClientContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<SportNutritionClient> SportNutritionClients => GetDbSet<SportNutritionClient>();
    }
}