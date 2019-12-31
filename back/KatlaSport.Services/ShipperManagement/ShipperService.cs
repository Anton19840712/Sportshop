using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ShipperDirectory;
using DbShipper = KatlaSport.DataAccess.ShipperDirectory.Shipper;

namespace KatlaSport.Services.ShipperManagement
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipperService"/> class with specified <see cref="IShipperCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IShipperDirectoryContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public ShipperService(IShipperContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<List<ShipperListItem>> GetShippersAsync()
        {
            var dbShipper = await _context.Shippers.OrderBy(s => s.ShipperID).ToArrayAsync();
            var shippers = dbShipper.Select(s => Mapper.Map<ShipperListItem>(s)).ToList();

            return shippers;
        }

        /// <inheritdoc/>
        public async Task<Shipper> GetShipperAsync(int shipperID)
        {
            var dbShipper = await _context.Shippers.Where(p => p.ShipperID == shipperID).ToArrayAsync();

            if (dbShipper.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbShipper, Shipper>(dbShipper[0]);
        }

        /// <inheritdoc/>
        public async Task<Shipper> CreateShipperAsync(UpdateShipperRequest createRequest)
        {
            var dbShipper = Mapper.Map<UpdateShipperRequest, DbShipper>(createRequest);

            _context.Shippers.Add(dbShipper);

            await _context.SaveChangesAsync();

            return Mapper.Map<Shipper>(dbShipper);
        }

        /// <inheritdoc/>
        public async Task<Shipper> UpdateShipperAsync(int shipperID, UpdateShipperRequest updateRequest)
        {
            var dbShippers = await _context.Shippers.Where(c => c.ShipperID == shipperID).ToArrayAsync();
            var dbShipper = dbShippers.FirstOrDefault();
            if (dbShipper == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbShipper);

            await _context.SaveChangesAsync();

            dbShippers = await _context.Shippers.Where(c => c.ShipperID == shipperID).ToArrayAsync();
            return dbShippers.Select(c => Mapper.Map<Shipper>(c)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task DeleteShipperAsync(int shipperID)
        {
            var dbShippers = await _context.Shippers.Where(c => c.ShipperID == shipperID).ToArrayAsync();

            if (dbShippers.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbShipper = dbShippers[0];

            _context.Shippers.Remove(dbShipper);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShipperListItem>> GetShippersAsync(int sportNutritionOrderId)
        {
            var dbShippers = await _context.Shippers.Where(s => s.SportNutritionOrderID == sportNutritionOrderId).OrderBy(s => s.ShipperID).ToArrayAsync();
            var shippers = dbShippers.Select(s => Mapper.Map<ShipperListItem>(s)).ToList();
            return shippers;
        }
    }
}
