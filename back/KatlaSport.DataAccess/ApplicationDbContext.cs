using System.Data.Entity;
using System.Reflection;
using KatlaSport.DataAccess.CustomerCatalogue;
using KatlaSport.DataAccess.Migrations;
using KatlaSport.DataAccess.OrderCommunication;
using KatlaSport.DataAccess.ProductCatalogue;
using KatlaSport.DataAccess.ProductStore;
using KatlaSport.DataAccess.ProductStoreHive;
using KatlaSport.DataAccess.ShipperDirectory;
using KatlaSport.DataAccess.SportNutritionClassDirectory;
using KatlaSport.DataAccess.SportNutritionClientDirectory;
using KatlaSport.DataAccess.SportNutritionOrderDirectory;
using KatlaSport.DataAccess.SportNutritionProductImageDirectory;
using KatlaSport.DataAccess.SportNutritionSubClassDirectory;
using KatlaSport.DataAccess.TransportCommunication;

namespace KatlaSport.DataAccess
{
    /// <summary>
    /// Represents an application database context.
    /// </summary>
    internal sealed class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>(true));

            // DatabaseLogger = databaseLogger;

            // if (DatabaseLogger != null)
            // {
            //    Database.Log = DatabaseLogger.LogDatabaseCall;
            // }
        }

        /// <summary>
        /// Gets or sets a database logger.
        /// </summary>
        public IDatabaseLogger DatabaseLogger { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="ProductCategory"/>.
        /// </summary>
        public DbSet<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="CatalogueProduct"/>.
        /// </summary>
        public DbSet<CatalogueProduct> CatalogueProducts { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreHive"/>.
        /// </summary>
        public DbSet<StoreHive> StoreHives { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreHiveSection"/>.
        /// </summary>
        public DbSet<StoreHiveSection> HiveSections { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreItem"/>.
        /// </summary>
        public DbSet<StoreItem> StoreItems { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreHiveSectionCategory"/>.
        /// </summary>
        public DbSet<StoreHiveSectionCategory> SectionCategories { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="Customer"/>.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="SportNutritionClass"/>.
        /// </summary>
        public DbSet<SportNutritionClass> SportNutritionClasses { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="SportNutritionSubClass"/>.
        /// </summary>
        public DbSet<SportNutritionSubClass> SportNutritionSubClasses { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="ProductImage"/>.
        /// </summary>
        public DbSet<SportNutritionProductImage> SportNutritionProductImages { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="SportNutritionOrder"/>.
        /// </summary>
        public DbSet<SportNutritionOrder> SportNutritionOrders { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="SportNutritionClient"/>.
        /// </summary>
        public DbSet<SportNutritionClient> SportNutritionClients { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Transport> Transports { get; set; }

        public DbSet<Information> Informations { get; set; }

        public DbSet<Mode> Modes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        /// <summary
        /// Overrides base method.
        /// </summary>
        /// <param name="modelBuilder"><see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
