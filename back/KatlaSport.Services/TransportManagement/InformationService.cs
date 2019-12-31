using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.TransportCommunication;
using DbINFO = KatlaSport.DataAccess.TransportCommunication.Information;

namespace KatlaSport.Services.TransportManagement
{
    public class InformationService : IRepository<Information, UpdateInformationRequest>
    {
        private readonly ITransportContext _context;

        public InformationService(ITransportContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Information> AddEntityAsync(UpdateInformationRequest entity)
        {
            var updateINFO = Mapper.Map<UpdateInformationRequest, DbINFO>(entity);
            _context.Informations.Add(updateINFO);

            await _context.SaveChangesAsync();
            return Mapper.Map<Information>(updateINFO);
        }

        public async Task<List<Information>> GetAllEntitiesAsync()
        {
            var dbINFOs = await _context.Informations.OrderBy(p => p.Id).ToArrayAsync();

            return dbINFOs.Select(p => Mapper.Map<Information>(p)).ToList();
        }

        public async Task<Information> GetEntityAsync(int id)
        {
            var dbINFOs = await _context.Informations.Where(p => p.Id == id).ToArrayAsync();

            if (dbINFOs.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbINFO, Information>(dbINFOs[0]);
        }

        public async Task RemoveEntityAsync(int id)
        {
            var dbINFOs = await _context.Informations.Where(p => p.Id == id).ToArrayAsync();
            if (dbINFOs.Length == 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbINFO = dbINFOs[0];
            _context.Informations.Remove(dbINFO);
            await _context.SaveChangesAsync();
        }

        public async Task<Information> UpdateEntityAsync(UpdateInformationRequest entity, int id)
        {
            var dbINFOs = await _context.Informations.Where(p => p.Id == id).ToArrayAsync();
            if (dbINFOs.Length == 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbINFO = dbINFOs[0];
            Mapper.Map(entity, dbINFO);
            await _context.SaveChangesAsync();
            return Mapper.Map<Information>(dbINFO);
        }
    }
}
