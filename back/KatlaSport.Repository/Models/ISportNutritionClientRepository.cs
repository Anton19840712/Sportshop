using System.Collections.Generic;

namespace KatlaSport.Repository.Models
{
    public interface ISportNutritionClientRepository
    {
        SportNutritionClient GetSportNutritionClient(int sportNutritionClientId);

        IEnumerable<SportNutritionClient> GetAllSportNutritionClients();

        SportNutritionClient AddSportNutritionClient(SportNutritionClient sportNutritionClient);

        SportNutritionClient UpdateSportNutritionClient(SportNutritionClient sportNutritionClientChanges);

        SportNutritionClient DeleteSportNutritionClient(int sportNutritionClientId);
    }
}
