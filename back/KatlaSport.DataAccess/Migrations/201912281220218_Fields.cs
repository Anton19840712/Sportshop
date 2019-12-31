namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// //////
    /// </summary>
    public partial class Fields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SportNutritionProductImages", "SportNutritionProductImageTitle", c => c.String());
            AddColumn("dbo.SportNutritionProductImages", "SportNutritionProductImageData", c => c.Binary());
        }

        public override void Down()
        {
            DropColumn("dbo.SportNutritionProductImages", "SportNutritionProductImageData");
            DropColumn("dbo.SportNutritionProductImages", "SportNutritionProductImageTitle");
        }
    }
}
