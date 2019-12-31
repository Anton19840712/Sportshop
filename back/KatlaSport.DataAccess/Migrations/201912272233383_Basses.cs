namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// ////
    /// </summary>
    public partial class Basses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.catalogue_products",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        product_description = c.String(maxLength: 300),
                        product_manufacturer_code = c.String(maxLength: 10),
                        product_price = c.Decimal(precision: 18, scale: 2),
                        product_name = c.String(nullable: false, maxLength: 60),
                        product_code = c.String(nullable: false, maxLength: 5),
                        product_category_id = c.Int(nullable: false),
                        deleted = c.Boolean(nullable: false),
                        created_by_id = c.Int(nullable: false),
                        created_utc = c.DateTime(nullable: false),
                        updated_by_id = c.Int(nullable: false),
                        updated_utc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("dbo.product_categories", t => t.product_category_id, cascadeDelete: true)
                .Index(t => t.product_code)
                .Index(t => t.product_category_id);

            CreateTable(
                "dbo.product_categories",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        category_description = c.String(maxLength: 300),
                        category_name = c.String(nullable: false, maxLength: 60),
                        category_code = c.String(nullable: false, maxLength: 5),
                        deleted = c.Boolean(nullable: false),
                        created_by_id = c.Int(nullable: false),
                        created_utc = c.DateTime(nullable: false),
                        updated_by_id = c.Int(nullable: false),
                        updated_utc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.category_id)
                .Index(t => t.category_code);

            CreateTable(
                "dbo.product_hive_section_categories",
                c => new
                    {
                        product_category_id = c.Int(nullable: false),
                        product_hive_section_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.product_category_id, t.product_hive_section_id })
                .ForeignKey("dbo.product_categories", t => t.product_category_id, cascadeDelete: true)
                .ForeignKey("dbo.product_hive_sections", t => t.product_hive_section_id, cascadeDelete: true)
                .Index(t => t.product_category_id)
                .Index(t => t.product_hive_section_id);

            CreateTable(
                "dbo.product_hive_sections",
                c => new
                    {
                        product_hive_section_id = c.Int(nullable: false, identity: true),
                        product_hive_section_name = c.String(nullable: false, maxLength: 60),
                        product_hive_code = c.String(nullable: false, maxLength: 5),
                        deleted = c.Boolean(nullable: false),
                        created_by_id = c.Int(nullable: false),
                        created_utc = c.DateTime(nullable: false),
                        updated_by_id = c.Int(nullable: false),
                        updated_utc = c.DateTime(nullable: false),
                        product_hive_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.product_hive_section_id)
                .ForeignKey("dbo.product_hives", t => t.product_hive_id, cascadeDelete: true)
                .Index(t => t.product_hive_id);

            CreateTable(
                "dbo.product_store_items",
                c => new
                    {
                        product_store_item_id = c.Int(nullable: false, identity: true),
                        product_store_item_product_id = c.Int(nullable: false),
                        product_store_item_hive_section_id = c.Int(nullable: false),
                        product_store_item_quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.product_store_item_id)
                .ForeignKey("dbo.product_hive_sections", t => t.product_store_item_hive_section_id, cascadeDelete: true)
                .ForeignKey("dbo.catalogue_products", t => t.product_store_item_product_id, cascadeDelete: true)
                .Index(t => t.product_store_item_product_id)
                .Index(t => t.product_store_item_hive_section_id);

            CreateTable(
                "dbo.order_products",
                c => new
                    {
                        order_products_id = c.Int(nullable: false, identity: true),
                        order_id = c.Int(nullable: false),
                        stored_item_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_products_id)
                .ForeignKey("dbo.order", t => t.order_id, cascadeDelete: true)
                .ForeignKey("dbo.product_store_items", t => t.stored_item_id, cascadeDelete: true)
                .Index(t => t.order_id)
                .Index(t => t.stored_item_id);

            CreateTable(
                "dbo.order",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        transport_id = c.Int(nullable: false),
                        order_acceptance_date = c.DateTime(nullable: false),
                        order_dispatch_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.customer_records", t => t.customer_id, cascadeDelete: true)
                .ForeignKey("dbo.transport", t => t.transport_id, cascadeDelete: true)
                .Index(t => t.customer_id)
                .Index(t => t.transport_id);

            CreateTable(
                "dbo.customer_records",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        customer_name = c.String(),
                        customer_address = c.String(),
                        customer_phone = c.String(),
                    })
                .PrimaryKey(t => t.customer_id);

            CreateTable(
                "dbo.transport",
                c => new
                    {
                        transport_id = c.Int(nullable: false, identity: true),
                        transport_name = c.String(nullable: false, maxLength: 200),
                        transport_mode_id = c.Int(nullable: false),
                        coordinator_transport_id = c.Int(),
                        transort_information_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.transport_id)
                .ForeignKey("dbo.transport", t => t.coordinator_transport_id)
                .ForeignKey("dbo.information", t => t.transort_information_id, cascadeDelete: true)
                .ForeignKey("dbo.mode", t => t.transport_mode_id, cascadeDelete: true)
                .Index(t => t.transport_mode_id)
                .Index(t => t.coordinator_transport_id)
                .Index(t => t.transort_information_id);

            CreateTable(
                "dbo.information",
                c => new
                    {
                        information_id = c.Int(nullable: false, identity: true),
                        file = c.Binary(nullable: false),
                        file_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.information_id);

            CreateTable(
                "dbo.mode",
                c => new
                    {
                        mode_id = c.Int(nullable: false, identity: true),
                        mode_type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.mode_id);

            CreateTable(
                "dbo.product_hives",
                c => new
                    {
                        product_hive_id = c.Int(nullable: false, identity: true),
                        product_hive_name = c.String(nullable: false, maxLength: 60),
                        product_hive_code = c.String(nullable: false, maxLength: 5),
                        product_hive_address = c.String(nullable: false, maxLength: 300),
                        deleted = c.Boolean(nullable: false),
                        created_by_id = c.Int(nullable: false),
                        created_utc = c.DateTime(nullable: false),
                        updated_by_id = c.Int(nullable: false),
                        updated_utc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.product_hive_id);

            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        ShipperName = c.String(),
                        ShipperPhone = c.String(),
                        SportNutritionOrderID = c.Int(nullable: false),
                        ShipperCoordinatorID = c.Int(),
                    })
                .PrimaryKey(t => t.ShipperID)
                .ForeignKey("dbo.Shippers", t => t.ShipperCoordinatorID)
                .ForeignKey("dbo.SportNutritionOrders", t => t.SportNutritionOrderID, cascadeDelete: true)
                .Index(t => t.SportNutritionOrderID)
                .Index(t => t.ShipperCoordinatorID);

            CreateTable(
                "dbo.SportNutritionOrders",
                c => new
                    {
                        SportNutritionOrderID = c.Int(nullable: false, identity: true),
                        SportNutritionClientID = c.Int(nullable: false),
                        SportNutritionSubClassID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        ShipperID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SportNutritionOrderID)
                .ForeignKey("dbo.SportNutritionClients", t => t.SportNutritionClientID, cascadeDelete: true)
                .Index(t => t.SportNutritionClientID);

            CreateTable(
                "dbo.SportNutritionClients",
                c => new
                    {
                        SportNutritionClientID = c.Int(nullable: false, identity: true),
                        SportNutritionClientName = c.String(),
                        SportNutritionClientCity = c.String(),
                        SportNutritionClientGender = c.String(),
                        SportNutritionClientAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SportNutritionClientID);

            CreateTable(
                "dbo.SportNutritionClasses",
                c => new
                    {
                        SportNutritionClassID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                    })
                .PrimaryKey(t => t.SportNutritionClassID);

            CreateTable(
                "dbo.SportNutritionSubClasses",
                c => new
                    {
                        SportNutritionSubClassID = c.Int(nullable: false, identity: true),
                        SubClassName = c.String(),
                        Protein = c.Int(nullable: false),
                        Fat = c.Int(nullable: false),
                        Carbohydrate = c.Int(nullable: false),
                        SportNutritionClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SportNutritionSubClassID)
                .ForeignKey("dbo.SportNutritionClasses", t => t.SportNutritionClassID, cascadeDelete: true)
                .Index(t => t.SportNutritionClassID);

            CreateTable(
                "dbo.SportNutritionProductImages",
                c => new
                    {
                        SportNutritionProductImageID = c.Int(nullable: false, identity: true),
                        SportNutritionProductImageName = c.String(),
                        SportNutritionSubClass_SportNutritionSubClassID = c.Int(),
                    })
                .PrimaryKey(t => t.SportNutritionProductImageID)
                .ForeignKey("dbo.SportNutritionSubClasses", t => t.SportNutritionSubClass_SportNutritionSubClassID)
                .Index(t => t.SportNutritionSubClass_SportNutritionSubClassID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.SportNutritionProductImages", "SportNutritionSubClass_SportNutritionSubClassID", "dbo.SportNutritionSubClasses");
            DropForeignKey("dbo.SportNutritionSubClasses", "SportNutritionClassID", "dbo.SportNutritionClasses");
            DropForeignKey("dbo.SportNutritionOrders", "SportNutritionClientID", "dbo.SportNutritionClients");
            DropForeignKey("dbo.Shippers", "SportNutritionOrderID", "dbo.SportNutritionOrders");
            DropForeignKey("dbo.Shippers", "ShipperCoordinatorID", "dbo.Shippers");
            DropForeignKey("dbo.catalogue_products", "product_category_id", "dbo.product_categories");
            DropForeignKey("dbo.product_hive_section_categories", "product_hive_section_id", "dbo.product_hive_sections");
            DropForeignKey("dbo.product_hive_sections", "product_hive_id", "dbo.product_hives");
            DropForeignKey("dbo.product_store_items", "product_store_item_product_id", "dbo.catalogue_products");
            DropForeignKey("dbo.order_products", "stored_item_id", "dbo.product_store_items");
            DropForeignKey("dbo.order_products", "order_id", "dbo.order");
            DropForeignKey("dbo.order", "transport_id", "dbo.transport");
            DropForeignKey("dbo.transport", "transport_mode_id", "dbo.mode");
            DropForeignKey("dbo.transport", "transort_information_id", "dbo.information");
            DropForeignKey("dbo.transport", "coordinator_transport_id", "dbo.transport");
            DropForeignKey("dbo.order", "customer_id", "dbo.customer_records");
            DropForeignKey("dbo.product_store_items", "product_store_item_hive_section_id", "dbo.product_hive_sections");
            DropForeignKey("dbo.product_hive_section_categories", "product_category_id", "dbo.product_categories");
            DropIndex("dbo.SportNutritionProductImages", new[] { "SportNutritionSubClass_SportNutritionSubClassID" });
            DropIndex("dbo.SportNutritionSubClasses", new[] { "SportNutritionClassID" });
            DropIndex("dbo.SportNutritionOrders", new[] { "SportNutritionClientID" });
            DropIndex("dbo.Shippers", new[] { "ShipperCoordinatorID" });
            DropIndex("dbo.Shippers", new[] { "SportNutritionOrderID" });
            DropIndex("dbo.transport", new[] { "transort_information_id" });
            DropIndex("dbo.transport", new[] { "coordinator_transport_id" });
            DropIndex("dbo.transport", new[] { "transport_mode_id" });
            DropIndex("dbo.order", new[] { "transport_id" });
            DropIndex("dbo.order", new[] { "customer_id" });
            DropIndex("dbo.order_products", new[] { "stored_item_id" });
            DropIndex("dbo.order_products", new[] { "order_id" });
            DropIndex("dbo.product_store_items", new[] { "product_store_item_hive_section_id" });
            DropIndex("dbo.product_store_items", new[] { "product_store_item_product_id" });
            DropIndex("dbo.product_hive_sections", new[] { "product_hive_id" });
            DropIndex("dbo.product_hive_section_categories", new[] { "product_hive_section_id" });
            DropIndex("dbo.product_hive_section_categories", new[] { "product_category_id" });
            DropIndex("dbo.product_categories", new[] { "category_code" });
            DropIndex("dbo.catalogue_products", new[] { "product_category_id" });
            DropIndex("dbo.catalogue_products", new[] { "product_code" });
            DropTable("dbo.SportNutritionProductImages");
            DropTable("dbo.SportNutritionSubClasses");
            DropTable("dbo.SportNutritionClasses");
            DropTable("dbo.SportNutritionClients");
            DropTable("dbo.SportNutritionOrders");
            DropTable("dbo.Shippers");
            DropTable("dbo.product_hives");
            DropTable("dbo.mode");
            DropTable("dbo.information");
            DropTable("dbo.transport");
            DropTable("dbo.customer_records");
            DropTable("dbo.order");
            DropTable("dbo.order_products");
            DropTable("dbo.product_store_items");
            DropTable("dbo.product_hive_sections");
            DropTable("dbo.product_hive_section_categories");
            DropTable("dbo.product_categories");
            DropTable("dbo.catalogue_products");
        }
    }
}
