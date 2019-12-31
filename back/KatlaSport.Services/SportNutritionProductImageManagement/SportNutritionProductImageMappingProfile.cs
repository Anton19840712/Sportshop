using AutoMapper;
using DataAccessSportNutritionProductImage = KatlaSport.DataAccess.SportNutritionProductImageDirectory.SportNutritionProductImage;

namespace KatlaSport.Services.SportNutritionProductImageManagement
{
    public sealed class SportNutritionProductImageMappingProfile : Profile
    {
        public SportNutritionProductImageMappingProfile()
        {
            CreateMap<DataAccessSportNutritionProductImage, SportNutritionProductImage>();
            CreateMap<UpdateSportNutritionProductImageRequest, DataAccessSportNutritionProductImage>();
        }
    }
}