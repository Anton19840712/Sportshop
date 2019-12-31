using System;
using AutoMapper;
using DataAccessOrder = KatlaSport.DataAccess.OrderCommunication.Order;
using DataAccessOrderProduct = KatlaSport.DataAccess.OrderCommunication.OrderProduct;

namespace KatlaSport.Services.OrderManagement
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<DataAccessOrder, Order>()
                .ForMember(o => o.CustomerId, opt => opt.MapFrom(o => o.CustomerId))
                .ForMember(o => o.TransportId, opt => opt.MapFrom(o => o.TransportId))
                .ForMember(o => o.OrderProducts, opt => opt.MapFrom(o => o.OrderProducts));
            CreateMap<DataAccessOrder, OrderListItem>()
                .ForMember(o => o.CustomerName, opt => opt.MapFrom(p => p.Customer.Name))
                .ForMember(o => o.TransportName, opt => opt.MapFrom(p => p.Transport.Name))
                .ForMember(o => o.TransportMode, opt => opt.MapFrom(p => p.Transport.Mode));
            CreateMap<DataAccessOrderProduct, OrderProduct>();
            CreateMap<UpdateOrderRequest, DataAccessOrder>()
                .ForMember(o => o.CustomerId, opt => opt.MapFrom(o => o.CustomerId))
                .ForMember(o => o.TransportId, opt => opt.MapFrom(o => o.TransportId))
                .ForMember(o => o.OrderProducts, opt => opt.MapFrom(o => o.OrderProducts))
                .ForMember(o => o.OrderAcceptanceDate, opt => opt.MapFrom(o => DateTime.UtcNow))
                .ForMember(o => o.OrderDispatchDate, opt => opt.MapFrom(o => DateTime.UtcNow))
                .AfterMap((model, entity) =>
                {
                    foreach (var entityOrderProduct in entity.OrderProducts)
                    {
                        foreach (var updateOrderProductRequest in model.OrderProducts)
                        {
                            entityOrderProduct.StoredItemId = updateOrderProductRequest.ProductId;
                        }
                    }
                });
            CreateMap<UpdateOrderProductRequest, DataAccessOrderProduct>();
        }
    }
}
