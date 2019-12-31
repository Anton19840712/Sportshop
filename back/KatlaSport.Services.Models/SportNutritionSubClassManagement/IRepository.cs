using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.SportNutritionSubClassManagement
{
    public interface IRepository
    {
        /// <summary>
        /// Gets a list of sportNutritionSubClasses.
        /// </summary>
        /// <returns>A <see cref="Task{List{SportNutritionSubClassListItem}}"/>.</returns>
        Task<List<SportNutritionSubClassListItem>> GetAllAsync();

        /// <summary>
        /// Gets a sportNutritionSubClass with specified identifier.
        /// </summary>
        /// <param name="sportNutritionSubClassID">A product category identifier.</param>
        /// <returns>A <see cref="Task{SportNutritionSubClass}"/>.</returns>
        Task<SportNutritionSubClass> FindByIdAsync(int sportNutritionSubClassID);

        /// <summary>
        /// Creates a new sportNutritionSubClass.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateSportNutritionSubClassRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionSubClass}"/>.</returns>
        Task<SportNutritionSubClass> CreateAsync(UpdateSportNutritionSubClassRequest createRequest);

        /// <summary>
        /// Updates an existed sportNutritionSubClass information.
        /// </summary>
        /// <param name="sportNutritionSubClassID">A product category identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateSportNutritionSubClassRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionSubClass}"/>.</returns>
        Task<SportNutritionSubClass> UpdateAsync(int sportNutritionSubClassID, UpdateSportNutritionSubClassRequest updateRequest);

        /// <summary>
        /// Deletes an existed sportNutritionSubClass.
        /// </summary>
        /// <param name="sportNutritionSubClassID">A product category identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task RemoveAsync(int sportNutritionSubClassID);
    }
}