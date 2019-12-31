using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.TransportCommunication;
using DbTransport = KatlaSport.DataAccess.TransportCommunication.Transport;

namespace KatlaSport.Services.TransportManagement
{
    public class TransportService : IRepository<Transport, UpdateTransportRequest>
    {
        private readonly ITransportContext _context;

        public TransportService(ITransportContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Transport> GetEntityAsync(int id)
        {
            var dbTransport = await _context.Transports.Where(e => e.Id == id).ToArrayAsync();

            if (dbTransport.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbTransport, Transport>(dbTransport[0]);
        }

        public async Task<List<Transport>> GetAllEntitiesAsync()
        {
            var dbTransports = await _context.Transports.OrderBy(e => e.Id).ToArrayAsync();
            return dbTransports.Select(h => Mapper.Map<Transport>(h)).ToList();
        }

        public async Task<Transport> AddEntityAsync(UpdateTransportRequest entity)
        {
            var dbTransport = Mapper.Map<UpdateTransportRequest, DbTransport>(entity);
            _context.Transports.Add(dbTransport);

            await _context.SaveChangesAsync();
            return Mapper.Map<Transport>(dbTransport);
        }

        public async Task RemoveEntityAsync(int id)
        {
            var dbTransports = await _context.Transports.Where(p => p.Id == id).ToArrayAsync();
            if (dbTransports.Length == 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbTransport = dbTransports[0];
            _context.Transports.Remove(dbTransport);
            await _context.SaveChangesAsync();
        }

        public async Task<Transport> UpdateEntityAsync(UpdateTransportRequest entity, int id)
        {
            var dbTransports = await _context.Transports.Where(p => p.Id == id).ToArrayAsync();
            if (dbTransports.Length == 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbTransport = dbTransports[0];
            Mapper.Map(entity, dbTransport);
            await _context.SaveChangesAsync();
            return Mapper.Map<Transport>(dbTransport);
        }
    }
}
