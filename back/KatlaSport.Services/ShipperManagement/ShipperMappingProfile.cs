using AutoMapper;
using DataAccessShipper = KatlaSport.DataAccess.ShipperDirectory.Shipper;

namespace KatlaSport.Services.ShipperManagement
{
    public sealed class ShipperMappingProfile : Profile
    {
        public ShipperMappingProfile()
        {
            CreateMap<DataAccessShipper, Shipper>();
            CreateMap<UpdateShipperRequest, DataAccessShipper>();
        }
    }
}