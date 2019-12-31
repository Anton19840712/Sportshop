using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ShipperManagement
{
    public interface IShipperService
    {
        /// <summary>
        /// Gets a list of sport nutrition classes.
        /// </summary>
        /// <returns>A <see cref="Task{List{ShipperListItem}}"/>.</returns>
        Task<List<ShipperListItem>> GetShippersAsync();

        /// <summary>
        /// Task lists shippers for a concrete order. добавочный метод
        /// </summary>
        /// <param name="sportNutritionOrderId">A client identifier.</param>
        /// <returns>A <see cref="Task{List{ShipperListItem}}"/>.</returns>
        Task<List<ShipperListItem>> GetShippersAsync(int sportNutritionOrderId);

        /// <summary>
        /// Gets a sport nutrition class with specified identifier.
        /// </summary>
        /// <param name="shipperID">A product category identifier.</param>
        /// <returns>A <see cref="Task{Shipper}"/>.</returns>
        Task<Shipper> GetShipperAsync(int shipperID);

        /// <summary>
        /// Creates a new sport nutrition class.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateShipperRequest"/>.</param>
        /// <returns>A <see cref="Task{Shipper}"/>.</returns>
        Task<Shipper> CreateShipperAsync(UpdateShipperRequest createRequest);

        /// <summary>
        /// Updates an existed sport nutrition class information.
        /// </summary>
        /// <param name="shipperID">A product category identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateShipperRequest"/>.</param>
        /// <returns>A <see cref="Task{Shipper}"/>.</returns>
        Task<Shipper> UpdateShipperAsync(int shipperID, UpdateShipperRequest updateRequest);

        /// <summary>
        /// Deletes an existed sport nutrition class.
        /// </summary>
        /// <param name="shipperID">A product category identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteShipperAsync(int shipperID);
    }
}