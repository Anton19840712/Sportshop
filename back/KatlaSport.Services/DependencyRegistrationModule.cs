using Autofac;

namespace KatlaSport.Services
{
    /// <summary>
    /// Represents an assembly dependency registration <see cref="Module"/>.
    /// </summary>
    public class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CatalogueManagement.CatalogueManagementService>().As<CatalogueManagement.ICatalogueManagementService>();
            builder.RegisterType<HiveManagement.HiveService>().As<HiveManagement.IHiveService>();
            builder.RegisterType<HiveAnalytics.HiveAnalysisService>().As<HiveAnalytics.IHiveAnalysisService>();
            builder.RegisterType<CustomerManagement.CustomerManagementService>().As<CustomerManagement.ICustomerManagementService>();
            builder.RegisterType<ProductManagement.ProductCategoryService>().As<ProductManagement.IProductCategoryService>();
            builder.RegisterType<ProductManagement.ProductCatalogueService>().As<ProductManagement.IProductCatalogueService>();
            builder.RegisterType<HiveManagement.HiveService>().As<HiveManagement.IHiveService>();
            builder.RegisterType<HiveManagement.HiveSectionService>().As<HiveManagement.IHiveSectionService>();
            builder.RegisterType<SportNutritionClassManagement.SportNutritionClassService>().As<SportNutritionClassManagement.ISportNutritionClassService>();
            builder.RegisterType<SportNutritionSubClassManagement.SportNutritionSubClassService>().As<SportNutritionSubClassManagement.ISportNutritionSubClassService>();
            builder.RegisterType<SportNutritionOrderManagement.SportNutritionOrderService>().As<SportNutritionOrderManagement.ISportNutritionOrderService>();
            builder.RegisterType<SportNutritionClientManagement.SportNutritionClientService>().As<SportNutritionClientManagement.ISportNutritionClientService>();
            builder.RegisterType<SportNutritionProductImageManagement.SportNutritionProductImageService>().As<SportNutritionProductImageManagement.ISportNutritionProductImageService>();
            builder.RegisterType<ShipperManagement.ShipperService>().As<ShipperManagement.IShipperService>();
            builder.RegisterType<UserContext>().As<IUserContext>();

            builder.RegisterType<SportNutritionSubClassManagement.Repository>().As<SportNutritionSubClassManagement.IRepository>();

            builder.RegisterType<TransportManagement.TransportService>().As<IRepository<TransportManagement.Transport, TransportManagement.UpdateTransportRequest>>();
            builder.RegisterType<TransportManagement.InformationService>().As<IRepository<TransportManagement.Information, TransportManagement.UpdateInformationRequest>>();
            builder.RegisterType<TransportManagement.ModeService>().As<IRepository<TransportManagement.Mode, TransportManagement.UpdateModeRequest>>();
            builder.RegisterType<OrderManagement.OrderService>().As<OrderManagement.IOrderService>();
        }
    }
}
