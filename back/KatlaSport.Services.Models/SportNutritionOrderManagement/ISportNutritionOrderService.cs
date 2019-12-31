using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.SportNutritionOrderManagement
{
    public interface ISportNutritionOrderService
    {
        /// <summary>
        /// Gets a list of sportNutritionOrders.
        /// </summary>
        /// <returns>A <see cref="Task{List{SportNutritionOrderListItem}}"/>.</returns>
        Task<List<SportNutritionOrderListItem>> GetSportNutritionOrdersAsync();

        /// <summary>
        /// Task lists orders for a concrete client.
        /// </summary>
        /// <param name="sportNutritionClientId">A client identifier.</param>
        /// <returns>A <see cref="Task{List{SportNutritionOrderListItem}}"/>.</returns>
        Task<List<SportNutritionOrderListItem>> GetSportNutritionOrdersAsync(int sportNutritionClientId);

        /// <summary>
        /// Gets a sportNutritionOrder with specified identifier.
        /// </summary>
        /// <param name="sportNutritionOrderID">A product category identifier.</param>
        /// <returns>A <see cref="Task{SportNutritionOrder}"/>.</returns>
        Task<SportNutritionOrder> GetSportNutritionOrderAsync(int sportNutritionOrderID);

        /// <summary>
        /// Creates a new sportNutritionOrder.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateSportNutritionOrderRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionOrder}"/>.</returns>
        Task<SportNutritionOrder> CreateSportNutritionOrderAsync(UpdateSportNutritionOrderRequest createRequest);

        /// <summary>
        /// Updates an existed sportNutritionOrder information.
        /// </summary>
        /// <param name="sportNutritionOrderID">A product category identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateSportNutritionOrderRequest"/>.</param>
        /// <returns>A <see cref="Task{SportNutritionOrder}"/>.</returns>
        Task<SportNutritionOrder> UpdateSportNutritionOrderAsync(int sportNutritionOrderID, UpdateSportNutritionOrderRequest updateRequest);

        /// <summary>
        /// Deletes an existed sportNutritionOrder.
        /// </summary>
        /// <param name="sportNutritionOrderID">A product category identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteSportNutritionOrderAsync(int sportNutritionOrderID);
    }
}