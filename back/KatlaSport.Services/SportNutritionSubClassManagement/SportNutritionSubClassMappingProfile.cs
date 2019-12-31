using AutoMapper;
using DataAccessSportNutritionSubClass = KatlaSport.DataAccess.SportNutritionSubClassDirectory.SportNutritionSubClass;

namespace KatlaSport.Services.SportNutritionSubClassManagement
{
    public sealed class SportNutritionSubClassMappingProfile : Profile
    {
        public SportNutritionSubClassMappingProfile()
        {
            CreateMap<DataAccessSportNutritionSubClass, SportNutritionSubClass>();
            CreateMap<UpdateSportNutritionSubClassRequest, DataAccessSportNutritionSubClass>();
        }
    }
}