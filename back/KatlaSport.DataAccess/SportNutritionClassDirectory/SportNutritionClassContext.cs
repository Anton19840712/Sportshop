namespace KatlaSport.DataAccess.SportNutritionClassDirectory
{
    internal sealed class SportNutritionClassContext : DomainContextBase<ApplicationDbContext>, ISportNutritionClassContext
    {
        public SportNutritionClassContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<SportNutritionClass> SportNutritionClasses => GetDbSet<SportNutritionClass>();
    }
}