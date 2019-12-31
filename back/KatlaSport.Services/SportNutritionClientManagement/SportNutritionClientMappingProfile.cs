using AutoMapper;
using DataAccessSportNutritionClient = KatlaSport.DataAccess.SportNutritionClientDirectory.SportNutritionClient;

namespace KatlaSport.Services.SportNutritionClientManagement
{
    public sealed class SportNutritionClientMappingProfile : Profile
    {
        public SportNutritionClientMappingProfile()
        {
            CreateMap<DataAccessSportNutritionClient, SportNutritionClient>();
            CreateMap<UpdateSportNutritionClientRequest, DataAccessSportNutritionClient>();
        }
    }
}