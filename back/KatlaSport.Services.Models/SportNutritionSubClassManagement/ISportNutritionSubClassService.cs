using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KatlaSport.Services.SportNutritionSubClassManagement
{
    public interface ISportNutritionSubClassService
    {
        /// <summary>
        /// Gets a list of sportNutritionSubClasses.
        /// </summary>
        /// <returns>A <see cref="Task{List{SportNutritionSubClassListItem}}"/>.</returns>
        Task<List<SportNutritionSubClassListItem>> GetSportNutritionSubClassesAsync();

        /// <summary>
        /// Gets a sportNutritionSubClass with specified identifier.
        /// </summary>
        /// <param name="sportNutritionSubClassID">A product category identifier.</param>
        /// <returns>A <see cref="Task{SportNutritionSubClass}"/>.</returns>
        Task<SportNutritionSubClass> GetSportNutritionSubClassAsync(int sportNutritionSubClassID);

        /// <summary>
        /// Creates a new sportNutritionSubClass.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateSportNutritionSubClassRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionSubClass}"/>.</returns>
        Task<SportNutritionSubClass> CreateSportNutritionSubClassAsync(UpdateSportNutritionSubClassRequest createRequest);

        /// <summary>
        /// Task lists hive sections for a concrete hive.
        /// </summary>
        /// <param name="sportNutritionClassId">A hive identifier.</param>
        /// <returns>A <see cref="Task{List{SportNutritionSubClassListItem}}"/>.</returns>
        Task<List<SportNutritionSubClassListItem>> GetSportNutritionSubClassesAsync(int sportNutritionClassId);

        /// <summary>
        /// Updates an existed sportNutritionSubClass information.
        /// </summary>
        /// <param name="sportNutritionSubClassID">A product category identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateSportNutritionSubClassRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionSubClass}"/>.</returns>
        Task<SportNutritionSubClass> UpdateSportNutritionSubClassAsync(int sportNutritionSubClassID, UpdateSportNutritionSubClassRequest updateRequest);

        /// <summary>
        /// Deletes an existed sportNutritionSubClass.
        /// </summary>
        /// <param name="sportNutritionSubClassID">A product category identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteSportNutritionSubClassAsync(int sportNutritionSubClassID);

        /// <summary>
        /// Upload an existed sportNutritionProductImage.
        /// </summary>
        /// <param name="provider">A <see cref="UpdateSportNutritionImageRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionSubClassImage}"/>.</returns>
        Task<SportNutritionSubClass> UploadSportNutritionSubClassImageAsync(MultipartMemoryStreamProvider provider);
    }
}
