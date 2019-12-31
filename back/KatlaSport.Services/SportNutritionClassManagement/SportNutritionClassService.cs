using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.SportNutritionClassDirectory;
using DbSportNutritionClass = KatlaSport.DataAccess.SportNutritionClassDirectory.SportNutritionClass;

namespace KatlaSport.Services.SportNutritionClassManagement
{
    public class SportNutritionClassService : ISportNutritionClassService
    {
        private readonly ISportNutritionClassContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SportNutritionClassService"/> class with specified <see cref="ISportNutritionClassCatalogueContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="ISportNutritionClassDirectoryContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public SportNutritionClassService(ISportNutritionClassContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<List<SportNutritionClassListItem>> GetSportNutritionClassesAsync()
        {
            var dbSportNutritionClass = await _context.SportNutritionClasses.OrderBy(s => s.SportNutritionClassID).ToArrayAsync();
            var sportNutritionClasses = dbSportNutritionClass.Select(s => Mapper.Map<SportNutritionClassListItem>(s)).ToList();

            return sportNutritionClasses;
        }

        /// <inheritdoc/>
        public async Task<SportNutritionClass> GetSportNutritionClassAsync(int sportNutritionClassID)
        {
            var dbSportNutritionClass = await _context.SportNutritionClasses.Where(p => p.SportNutritionClassID == sportNutritionClassID).ToArrayAsync();

            if (dbSportNutritionClass.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbSportNutritionClass, SportNutritionClass>(dbSportNutritionClass[0]);
        }

        /// <inheritdoc/>
        public async Task<SportNutritionClass> CreateSportNutritionClassAsync(UpdateSportNutritionClassRequest createRequest)
        {
            var dbSportNutritionClass = Mapper.Map<UpdateSportNutritionClassRequest, DbSportNutritionClass>(createRequest);

            _context.SportNutritionClasses.Add(dbSportNutritionClass);

            await _context.SaveChangesAsync();

            return Mapper.Map<SportNutritionClass>(dbSportNutritionClass);
        }

        /// <inheritdoc/>
        public async Task<SportNutritionClass> UpdateSportNutritionClassAsync(int sportNutritionClassID, UpdateSportNutritionClassRequest updateRequest)
        {
            var dbSportNutritionClasses = await _context.SportNutritionClasses.Where(c => c.SportNutritionClassID == sportNutritionClassID).ToArrayAsync();
            var dbSportNutritionClass = dbSportNutritionClasses.FirstOrDefault();
            if (dbSportNutritionClass == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbSportNutritionClass);

            await _context.SaveChangesAsync();

            dbSportNutritionClasses = await _context.SportNutritionClasses.Where(c => c.SportNutritionClassID == sportNutritionClassID).ToArrayAsync();
            return dbSportNutritionClasses.Select(c => Mapper.Map<SportNutritionClass>(c)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task DeleteSportNutritionClassAsync(int sportNutritionClassID)
        {
            var dbSportNutritionClasses = await _context.SportNutritionClasses.Where(c => c.SportNutritionClassID == sportNutritionClassID).ToArrayAsync();

            if (dbSportNutritionClasses.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbSportNutritionClass = dbSportNutritionClasses[0];

            _context.SportNutritionClasses.Remove(dbSportNutritionClass);
            await _context.SaveChangesAsync();
        }
    }
}
