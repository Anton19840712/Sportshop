using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.TransportCommunication;
using DbMode = KatlaSport.DataAccess.TransportCommunication.Mode;

namespace KatlaSport.Services.TransportManagement
{
    public class ModeService : IRepository<Mode, UpdateModeRequest>
    {
        private readonly ITransportContext _context;

        public ModeService(ITransportContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Mode>> GetAllEntitiesAsync()
        {
            var dbModes = await _context.Modes.OrderBy(e => e.Id).ToArrayAsync();
            return dbModes.Select(p => Mapper.Map<Mode>(p)).ToList();
        }

        public async Task<Mode> GetEntityAsync(int id)
        {
            var dbModes = await _context.Modes.Where(e => e.Id == id).ToArrayAsync();

            if (dbModes.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbMode, Mode>(dbModes[0]);
        }

        public async Task<Mode> AddEntityAsync(UpdateModeRequest entity)
        {

            var dbMode = Mapper.Map<UpdateModeRequest, DbMode>(entity);
            _context.Modes.Add(dbMode);

            await _context.SaveChangesAsync();
            return Mapper.Map<Mode>(dbMode);
        }

        public async Task RemoveEntityAsync(int id)
        {
            var dbModes = await _context.Modes.Where(p => p.Id == id).ToArrayAsync();
            if (dbModes.Length == 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbMode = dbModes[0];
            _context.Modes.Remove(dbMode);
            await _context.SaveChangesAsync();
        }

        public async Task<Mode> UpdateEntityAsync(UpdateModeRequest entity, int id)
        {
            var dbModes = await _context.Modes.Where(p => p.Id == id).ToArrayAsync();
            if (dbModes.Length == 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbMode = dbModes[0];
            Mapper.Map(entity, dbMode);
            await _context.SaveChangesAsync();
            return Mapper.Map<Mode>(dbMode);
        }
    }
}
