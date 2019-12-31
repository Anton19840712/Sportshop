using AutoMapper;
using DataAccessSportNutritionClass = KatlaSport.DataAccess.SportNutritionClassDirectory.SportNutritionClass;

namespace KatlaSport.Services.SportNutritionClassManagement
{
    public sealed class SportNutritionClassMappingProfile : Profile
    {
        public SportNutritionClassMappingProfile()
        {
            CreateMap<DataAccessSportNutritionClass, SportNutritionClass>();
            CreateMap<UpdateSportNutritionClassRequest, DataAccessSportNutritionClass>();
        }
    }
}