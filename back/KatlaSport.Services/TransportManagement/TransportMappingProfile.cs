using AutoMapper;
using DataAccessInformation = KatlaSport.DataAccess.TransportCommunication.Information;
using DataAccessMode = KatlaSport.DataAccess.TransportCommunication.Mode;
using DataAccessTransport = KatlaSport.DataAccess.TransportCommunication.Transport;

namespace KatlaSport.Services.TransportManagement
{
    public sealed class TransportMappingProfile : Profile
    {
        public TransportMappingProfile()
        {
            CreateMap<DataAccessTransport, Transport>();
            CreateMap<DataAccessInformation, Information>();
            CreateMap<DataAccessMode, Mode>();

            CreateMap<Transport, UpdateTransportRequest>();
            CreateMap<Information, UpdateInformationRequest>();
            CreateMap<Mode, UpdateModeRequest>();

            CreateMap<UpdateTransportRequest, DataAccessTransport>();
            CreateMap<UpdateModeRequest, DataAccessMode>();

            CreateMap<Transport, DataAccessTransport>()
                .ForMember(e => e.ModeId, opt => opt.MapFrom(p => p.ModeId))
                .ForMember(e => e.InformationId, opt => opt.MapFrom(p => p.InformationId))
                .ForMember(e => e.CoordinatorId, opt => opt.MapFrom(p => p.CoordinatorId))
                .ForMember(p => p.Mode, opt => opt.Ignore())
                .ForMember(p => p.Information, opt => opt.Ignore())
                .ForMember(p => p.Coordinator, opt => opt.Ignore());
        }
    }
}
