namespace KatlaSport.DataAccess.SportNutritionSubClassDirectory
{
    internal sealed class SportNutritionSubClassContext : DomainContextBase<ApplicationDbContext>, ISportNutritionSubClassContext
    {
        public SportNutritionSubClassContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<SportNutritionSubClass> SportNutritionSubClasses => GetDbSet<SportNutritionSubClass>();
    }
}