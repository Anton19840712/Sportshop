namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// /
    /// </summary>
    public partial class FieldImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SportNutritionSubClasses", "Image", c => c.Binary());
        }

        public override void Down()
        {
            DropColumn("dbo.SportNutritionSubClasses", "Image");
        }
    }
}
