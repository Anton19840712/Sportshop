using Autofac;

namespace KatlaSport.DataAccess
{
    /// <summary>
    /// Represents an assembly dependency registration <see cref="Module"/>.
    /// </summary>
    public sealed class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();
            builder.RegisterType<ProductCatalogue.ProductCatalogueContext>().As<ProductCatalogue.IProductCatalogueContext>().InstancePerRequest();
            builder.RegisterType<ProductStoreHive.ProductStoreHiveContext>().As<ProductStoreHive.IProductStoreHiveContext>().InstancePerRequest();
            builder.RegisterType<ProductStore.ProductStoreContext>().As<ProductStore.IProductStoreContext>().InstancePerRequest();
            builder.RegisterType<CustomerCatalogue.CustomerContext>().As<CustomerCatalogue.ICustomerContext>().InstancePerRequest();
            builder.RegisterType<SportNutritionClassDirectory.SportNutritionClassContext>().As<SportNutritionClassDirectory.ISportNutritionClassContext>().InstancePerRequest();
            builder.RegisterType<SportNutritionSubClassDirectory.SportNutritionSubClassContext>().As<SportNutritionSubClassDirectory.ISportNutritionSubClassContext>().InstancePerRequest();
            builder.RegisterType<SportNutritionProductImageDirectory.SportNutritionProductImageContext>().As<SportNutritionProductImageDirectory.ISportNutritionProductImageContext>().InstancePerRequest();
            builder.RegisterType<SportNutritionOrderDirectory.SportNutritionOrderContext>().As<SportNutritionOrderDirectory.ISportNutritionOrderContext>().InstancePerRequest();
            builder.RegisterType<SportNutritionClientDirectory.SportNutritionClientContext>().As<SportNutritionClientDirectory.ISportNutritionClientContext>().InstancePerRequest();
            builder.RegisterType<ShipperDirectory.ShipperContext>().As<ShipperDirectory.IShipperContext>().InstancePerRequest();
            builder.RegisterType<DebugDatabaseLogger>().As<IDatabaseLogger>();
            builder.RegisterType<TransportCommunication.TransportContext>().As<TransportCommunication.ITransportContext>().InstancePerRequest();
            builder.RegisterType<OrderCommunication.OrderContext>().As<OrderCommunication.IOrderContext>().InstancePerRequest();
        }
    }
}
