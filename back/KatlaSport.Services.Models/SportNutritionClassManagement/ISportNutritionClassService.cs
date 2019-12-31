using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.SportNutritionClassManagement
{
    public interface ISportNutritionClassService
    {
        /// <summary>
        /// Gets a list of sport nutrition classes.
        /// </summary>
        /// <returns>A <see cref="Task{List{SportNutritionClassListItem}}"/>.</returns>
        Task<List<SportNutritionClassListItem>> GetSportNutritionClassesAsync();

        /// <summary>
        /// Gets a sport nutrition class with specified identifier.
        /// </summary>
        /// <param name="sportNutritionClassID">A product category identifier.</param>
        /// <returns>A <see cref="Task{SportNutritionClass}"/>.</returns>
        Task<SportNutritionClass> GetSportNutritionClassAsync(int sportNutritionClassID);

        /// <summary>
        /// Creates a new sport nutrition class.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateSportNutritionClassRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionClass}"/>.</returns>
        Task<SportNutritionClass> CreateSportNutritionClassAsync(UpdateSportNutritionClassRequest createRequest);

        /// <summary>
        /// Updates an existed sport nutrition class information.
        /// </summary>
        /// <param name="sportNutritionClassID">A product category identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateSportNutritionClassRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionClass}"/>.</returns>
        Task<SportNutritionClass> UpdateSportNutritionClassAsync(int sportNutritionClassID, UpdateSportNutritionClassRequest updateRequest);

        /// <summary>
        /// Deletes an existed sport nutrition class.
        /// </summary>
        /// <param name="sportNutritionClassID">A product category identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteSportNutritionClassAsync(int sportNutritionClassID);
    }
}