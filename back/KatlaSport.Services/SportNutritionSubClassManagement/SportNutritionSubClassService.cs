using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.SportNutritionSubClassDirectory;
using DbSportNutritionSubClass = KatlaSport.DataAccess.SportNutritionSubClassDirectory.SportNutritionSubClass;

namespace KatlaSport.Services.SportNutritionSubClassManagement
{
    public class SportNutritionSubClassService : ISportNutritionSubClassService
    {
        private readonly ISportNutritionSubClassContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SportNutritionSubClassService"/> class with specified <see cref="ISportNutritionSubClassDirectoryContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="ISportNutritionSubClassDirectoryContext"/>.</param>
        public SportNutritionSubClassService(ISportNutritionSubClassContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<SportNutritionSubClass> GetSportNutritionSubClassAsync(int sportNutritionSubClassID)
        {
            var dbSportNutritionSubClass = await _context.SportNutritionSubClasses.Where(p => p.SportNutritionSubClassID == sportNutritionSubClassID).ToArrayAsync();

            if (dbSportNutritionSubClass.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbSportNutritionSubClass, SportNutritionSubClass>(dbSportNutritionSubClass[0]);
        }

        /// <inheritdoc/> создаю новый supplementshoper
        public async Task<SportNutritionSubClass> CreateSportNutritionSubClassAsync(UpdateSportNutritionSubClassRequest createRequest)
        {
            var dbSportNutritionSubClass = Mapper.Map<UpdateSportNutritionSubClassRequest, DbSportNutritionSubClass>(createRequest);

            _context.SportNutritionSubClasses.Add(dbSportNutritionSubClass);

            await _context.SaveChangesAsync();

            return Mapper.Map<SportNutritionSubClass>(dbSportNutritionSubClass);
        }

        /// <inheritdoc/>
        public async Task<SportNutritionSubClass> UpdateSportNutritionSubClassAsync(int sportNutritionSubClassID, UpdateSportNutritionSubClassRequest updateRequest)
        {
            var dbSportNutritionSubClasses = await _context.SportNutritionSubClasses.Where(c => c.SportNutritionSubClassID == sportNutritionSubClassID).ToArrayAsync();
            var dbSportNutritionSubClass = dbSportNutritionSubClasses.FirstOrDefault();
            if (dbSportNutritionSubClass == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbSportNutritionSubClass);

            await _context.SaveChangesAsync();

            dbSportNutritionSubClasses = await _context.SportNutritionSubClasses.Where(c => c.SportNutritionSubClassID == sportNutritionSubClassID).ToArrayAsync();
            return dbSportNutritionSubClasses.Select(c => Mapper.Map<SportNutritionSubClass>(c)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task DeleteSportNutritionSubClassAsync(int sportNutritionSubClassID)
        {
            var dbSportNutritionSubClasses = await _context.SportNutritionSubClasses.Where(c => c.SportNutritionSubClassID == sportNutritionSubClassID).ToArrayAsync();

            if (dbSportNutritionSubClasses.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbSportNutritionSubClass = dbSportNutritionSubClasses[0];

            _context.SportNutritionSubClasses.Remove(dbSportNutritionSubClass);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<List<SportNutritionSubClassListItem>> GetSportNutritionSubClassesAsync()
        {
            var dbSportNutritionSubClass = await _context.SportNutritionSubClasses.OrderBy(s => s.SportNutritionSubClassID).ToArrayAsync();
            var supplementShopers = dbSportNutritionSubClass.Select(s => Mapper.Map<SportNutritionSubClassListItem>(s)).ToList();

            return supplementShopers;
        }

        public async Task<List<SportNutritionSubClassListItem>> GetSportNutritionSubClassesAsync(int sportNutritionClassId)
        {
            var dbSportNutritionSubClasses = await _context.SportNutritionSubClasses.Where(s => s.SportNutritionClassID == sportNutritionClassId).OrderBy(s => s.SportNutritionSubClassID).ToArrayAsync();
            var sportNutritionSubClasses = dbSportNutritionSubClasses.Select(s => Mapper.Map<SportNutritionSubClassListItem>(s)).ToList();
            return sportNutritionSubClasses;
        }

        /// <inheritdoc/>
        public async Task<SportNutritionSubClass> UploadSportNutritionSubClassImageAsync(MultipartMemoryStreamProvider provider)
        {
            var dbSportNutritionSubClass = new DbSportNutritionSubClass();

            foreach (var file in provider.Contents)
            {
                dbSportNutritionSubClass.Image = await file.ReadAsByteArrayAsync();
            }

            _context.SportNutritionSubClasses.Add(dbSportNutritionSubClass);
            await _context.SaveChangesAsync();
            return Mapper.Map<SportNutritionSubClass>(dbSportNutritionSubClass);
        }
    }
}
