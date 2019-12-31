using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.SportNutritionClientManagement
{
    public interface ISportNutritionClientService
    {
        /// <summary>
        /// Gets a list of supplements.
        /// </summary>
        /// <returns>A <see cref="Task{List{SportNutritionClientListItem}}"/>.</returns>
        Task<List<SportNutritionClientListItem>> GetSportNutritionClientsAsync();

        /// <summary>
        /// Gets a supplement with specified identifier.
        /// </summary>
        /// <param name="sportNutritionClientID">A product category identifier.</param>
        /// <returns>A <see cref="Task{SportNutritionClient}"/>.</returns>
        Task<SportNutritionClient> GetSportNutritionClientAsync(int sportNutritionClientID);

        /// <summary>
        /// Creates a new supplement.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateSportNutritionClientRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionClient}"/>.</returns>
        Task<SportNutritionClient> CreateSportNutritionClientAsync(UpdateSportNutritionClientRequest createRequest);

        /// <summary>
        /// Updates an existed supplement information.
        /// </summary>
        /// <param name="sportNutritionClientID">A product category identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateSportNutritionClientRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionClient}"/>.</returns>
        Task<SportNutritionClient> UpdateSportNutritionClientAsync(int sportNutritionClientID, UpdateSportNutritionClientRequest updateRequest);

        /// <summary>
        /// Deletes an existed supplement.
        /// </summary>
        /// <param name="sportNutritionClientID">A product category identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteSportNutritionClientAsync(int sportNutritionClientID);
    }
}