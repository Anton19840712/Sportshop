namespace KatlaSport.DataAccess.SportNutritionProductImageDirectory
{
    internal sealed class SportNutritionProductImageContext : DomainContextBase<ApplicationDbContext>, ISportNutritionProductImageContext
    {
        public SportNutritionProductImageContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<SportNutritionProductImage> SportNutritionProductImages => GetDbSet<SportNutritionProductImage>();
    }
}