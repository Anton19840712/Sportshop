using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.SportNutritionClientDirectory;
using DbSportNutritionClient = KatlaSport.DataAccess.SportNutritionClientDirectory.SportNutritionClient;

namespace KatlaSport.Services.SportNutritionClientManagement
{
    public class SportNutritionClientService : ISportNutritionClientService
    {
        private readonly ISportNutritionClientContext _context;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SportNutritionClientService"/> class with specified <see cref="ISportNutritionClientCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="ISportNutritionClientCatalogueContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public SportNutritionClientService(ISportNutritionClientContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException();
            _userContext = userContext ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<List<SportNutritionClientListItem>> GetSportNutritionClientsAsync()
        {
            var dbSportNutritionClient = await _context.SportNutritionClients.OrderBy(s => s.SportNutritionClientID).ToArrayAsync();
            var sportNutritionClients = dbSportNutritionClient.Select(s => Mapper.Map<SportNutritionClientListItem>(s)).ToList();

            return sportNutritionClients;
        }

        /// <inheritdoc/>
        public async Task<SportNutritionClient> GetSportNutritionClientAsync(int sportNutritionClientID)
        {
            var dbSportNutritionClient = await _context.SportNutritionClients.Where(p => p.SportNutritionClientID == sportNutritionClientID).ToArrayAsync();

            if (dbSportNutritionClient.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbSportNutritionClient, SportNutritionClient>(dbSportNutritionClient[0]);
        }

        /// <inheritdoc/>
        public async Task<SportNutritionClient> CreateSportNutritionClientAsync(UpdateSportNutritionClientRequest createRequest)
        {
            var dbSportNutritionClient = Mapper.Map<UpdateSportNutritionClientRequest, DbSportNutritionClient>(createRequest);

            _context.SportNutritionClients.Add(dbSportNutritionClient);

            await _context.SaveChangesAsync();

            return Mapper.Map<SportNutritionClient>(dbSportNutritionClient);
        }

        /// <inheritdoc/>
        public async Task<SportNutritionClient> UpdateSportNutritionClientAsync(int sportNutritionClientID, UpdateSportNutritionClientRequest updateRequest)
        {
            var dbSportNutritionClients = await _context.SportNutritionClients.Where(c => c.SportNutritionClientID == sportNutritionClientID).ToArrayAsync();
            var dbSportNutritionClient = dbSportNutritionClients.FirstOrDefault();
            if (dbSportNutritionClient == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbSportNutritionClient);

            await _context.SaveChangesAsync();

            dbSportNutritionClients = await _context.SportNutritionClients.Where(c => c.SportNutritionClientID == sportNutritionClientID).ToArrayAsync();
            return dbSportNutritionClients.Select(c => Mapper.Map<SportNutritionClient>(c)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task DeleteSportNutritionClientAsync(int sportNutritionClientID)
        {
            var dbSportNutritionClients = await _context.SportNutritionClients.Where(c => c.SportNutritionClientID == sportNutritionClientID).ToArrayAsync();

            if (dbSportNutritionClients.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbSportNutritionClient = dbSportNutritionClients[0];

            _context.SportNutritionClients.Remove(dbSportNutritionClient);
            await _context.SaveChangesAsync();
        }
    }
}
