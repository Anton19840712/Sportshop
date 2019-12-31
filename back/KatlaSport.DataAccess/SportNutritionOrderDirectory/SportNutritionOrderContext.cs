namespace KatlaSport.DataAccess.SportNutritionOrderDirectory
{
    internal sealed class SportNutritionOrderContext : DomainContextBase<ApplicationDbContext>, ISportNutritionOrderContext
    {
        public SportNutritionOrderContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<SportNutritionOrder> SportNutritionOrders => GetDbSet<SportNutritionOrder>();
    }
}