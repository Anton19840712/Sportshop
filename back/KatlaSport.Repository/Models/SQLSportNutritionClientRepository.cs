using System.Collections.Generic;

namespace KatlaSport.Repository.Models
{
    public class SQLSportNutritionClientRepository : ISportNutritionClientRepository
    {
        private readonly AppDbContext _context;

        public SQLSportNutritionClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public SportNutritionClient AddSportNutritionClient(SportNutritionClient sportNutritionClient)
        {
            _context.SportNutritionClients.Add(sportNutritionClient);
            _context.SportNutritionClients.Add(sportNutritionClient);
            return sportNutritionClient;
        }

        public SportNutritionClient DeleteSportNutritionClient(int sportNutritionClientId)
        {
            SportNutritionClient sportNutritionClient = _context.SportNutritionClients.Find(sportNutritionClientId);
            if (sportNutritionClient != null)
            {
                _context.SportNutritionClients.Remove(sportNutritionClient);
                _context.SaveChanges();
            }

            return sportNutritionClient;
        }

        public IEnumerable<SportNutritionClient> GetAllSportNutritionClients()
        {
            return _context.SportNutritionClients;
        }

        public SportNutritionClient GetSportNutritionClient(int sportNutritionClientId)
        {
            return _context.SportNutritionClients.Find(sportNutritionClientId);
        }

        public SportNutritionClient UpdateSportNutritionClient(SportNutritionClient sportNutritionClientChanges)
        {
            var sportNutritionClient = _context.SportNutritionClients.Attach(sportNutritionClientChanges);
            sportNutritionClient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return sportNutritionClientChanges;
        }
    }
}