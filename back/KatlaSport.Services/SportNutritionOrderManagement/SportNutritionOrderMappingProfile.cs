using AutoMapper;
using DataAccessSportNutritionOrder = KatlaSport.DataAccess.SportNutritionOrderDirectory.SportNutritionOrder;

namespace KatlaSport.Services.SportNutritionOrderManagement
{
    public sealed class SportNutritionOrderMappingProfile : Profile
    {
        public SportNutritionOrderMappingProfile()
        {
            CreateMap<DataAccessSportNutritionOrder, SportNutritionOrder>();
            CreateMap<UpdateSportNutritionOrderRequest, DataAccessSportNutritionOrder>();
        }
    }
}