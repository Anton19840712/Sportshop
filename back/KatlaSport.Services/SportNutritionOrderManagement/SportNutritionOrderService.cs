using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.SportNutritionOrderDirectory;
using DbSportNutritionOrder = KatlaSport.DataAccess.SportNutritionOrderDirectory.SportNutritionOrder;

namespace KatlaSport.Services.SportNutritionOrderManagement
{
    public class SportNutritionOrderService : ISportNutritionOrderService
    {
        private readonly ISportNutritionOrderContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SportNutritionOrderService"/> class with specified <see cref="ISportNutritionOrderDirectoryContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="ISportNutritionOrderDirectoryContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public SportNutritionOrderService(ISportNutritionOrderContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<List<SportNutritionOrderListItem>> GetSportNutritionOrdersAsync()
        {
            var dbSportNutritionOrder = await _context.SportNutritionOrders.OrderBy(s => s.SportNutritionOrderID).ToArrayAsync();
            var sportNutritionOrders = dbSportNutritionOrder.Select(s => Mapper.Map<SportNutritionOrderListItem>(s)).ToList();

            return sportNutritionOrders;
        }

        /// <inheritdoc/>
        public async Task<SportNutritionOrder> GetSportNutritionOrderAsync(int sportNutritionOrderID)
        {
            var dbSportNutritionOrder = await _context.SportNutritionOrders.Where(p => p.SportNutritionOrderID == sportNutritionOrderID).ToArrayAsync();

            if (dbSportNutritionOrder.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbSportNutritionOrder, SportNutritionOrder>(dbSportNutritionOrder[0]);
        }

        /// <inheritdoc/>
        public async Task<SportNutritionOrder> CreateSportNutritionOrderAsync(UpdateSportNutritionOrderRequest createRequest)
        {
            var dbSportNutritionOrder = Mapper.Map<UpdateSportNutritionOrderRequest, DbSportNutritionOrder>(createRequest);

            _context.SportNutritionOrders.Add(dbSportNutritionOrder);

            await _context.SaveChangesAsync();

            return Mapper.Map<SportNutritionOrder>(dbSportNutritionOrder);
        }

        /// <inheritdoc/>
        public async Task<SportNutritionOrder> UpdateSportNutritionOrderAsync(int sportNutritionOrderID, UpdateSportNutritionOrderRequest updateRequest)
        {
            var dbSportNutritionOrders = await _context.SportNutritionOrders.Where(c => c.SportNutritionOrderID == sportNutritionOrderID).ToArrayAsync();
            var dbSportNutritionOrder = dbSportNutritionOrders.FirstOrDefault();
            if (dbSportNutritionOrder == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbSportNutritionOrder);

            await _context.SaveChangesAsync();

            dbSportNutritionOrders = await _context.SportNutritionOrders.Where(c => c.SportNutritionOrderID == sportNutritionOrderID).ToArrayAsync();
            return dbSportNutritionOrders.Select(c => Mapper.Map<SportNutritionOrder>(c)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task DeleteSportNutritionOrderAsync(int sportNutritionOrderID)
        {
            var dbSportNutritionOrders = await _context.SportNutritionOrders.Where(c => c.SportNutritionOrderID == sportNutritionOrderID).ToArrayAsync();

            if (dbSportNutritionOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbSportNutritionOrder = dbSportNutritionOrders[0];

            _context.SportNutritionOrders.Remove(dbSportNutritionOrder);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SportNutritionOrderListItem>> GetSportNutritionOrdersAsync(int sportNutritionClientId)
        {
            var dbSportNutritionOrders = await _context.SportNutritionOrders.Where(s => s.SportNutritionClientID == sportNutritionClientId).OrderBy(s => s.SportNutritionOrderID).ToArrayAsync();
            var sportNutritionOrders = dbSportNutritionOrders.Select(s => Mapper.Map<SportNutritionOrderListItem>(s)).ToList();
            return sportNutritionOrders;
        }
    }
}
