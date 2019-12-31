using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KatlaSport.Services.SportNutritionProductImageManagement
{
    public interface ISportNutritionProductImageService
    {
        /// <summary>
        /// Gets a list of sportNutritionProductImages.
        /// </summary>
        /// <returns>A <see cref="Task{List{SportNutritionProductImageListItem}}"/>.</returns>
        Task<List<SportNutritionProductImageListItem>> GetSportNutritionProductImagesAsync();

        /// <summary>
        /// Gets a sportNutritionProductImage with specified identifier.
        /// </summary>
        /// <param name="sportNutritionProductImageID">A product category identifier.</param>
        /// <returns>A <see cref="Task{SportNutritionProductImage}"/>.</returns>
        Task<SportNutritionProductImage> GetSportNutritionProductImageAsync(int sportNutritionProductImageID);

        /// <summary>
        /// Creates a new sportNutritionProductImage.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateSportNutritionProductImageRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionProductImage}"/>.</returns>
        Task<SportNutritionProductImage> CreateSportNutritionProductImageAsync(UpdateSportNutritionProductImageRequest createRequest);

        /// <summary>
        /// Updates an existed sportNutritionProductImage information.
        /// </summary>
        /// <param name="sportNutritionProductImageID">A product category identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateSportNutritionProductImageRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionProductImage}"/>.</returns>
        Task<SportNutritionProductImage> UpdateSportNutritionProductImageAsync(int sportNutritionProductImageID, UpdateSportNutritionProductImageRequest updateRequest);

        /// <summary>
        /// Deletes an existed sportNutritionProductImage.
        /// </summary>
        /// <param name="sportNutritionProductImageID">A product category identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteSportNutritionProductImageAsync(int sportNutritionProductImageID);

        /// <summary>
        /// Upload an existed sportNutritionProductImage.
        /// </summary>
        /// <param name="provider">A <see cref="UpdateSportNutritionProductImageRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionProductImage}"/>.</returns>
        Task<SportNutritionProductImage> UploadSportNutritionProductImageAsync(MultipartMemoryStreamProvider provider);
    }
}
