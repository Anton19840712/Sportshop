using System.Collections.Generic;
using System.Linq;

namespace KatlaSport.Repository.Models
{
    public class MockSportNutritionClientRepository : ISportNutritionClientRepository
    {
        private readonly List<SportNutritionClient> _sportNutritionClientList;

        public MockSportNutritionClientRepository()
        {
            _sportNutritionClientList = new List<SportNutritionClient>()
            {
                new SportNutritionClient() { SportNutritionClientID = 1, SportNutritionClientName = "Anton", SportNutritionClientCity = "Moscow", SportNutritionClientGender = "Male", SportNutritionClientAge = 34 },
                new SportNutritionClient() { SportNutritionClientID = 2, SportNutritionClientName = "Igor", SportNutritionClientCity = "Minsk", SportNutritionClientGender = "Male", SportNutritionClientAge = 23 },
                new SportNutritionClient() { SportNutritionClientID = 3, SportNutritionClientName = "Victor", SportNutritionClientCity = "Gomel", SportNutritionClientGender = "Male", SportNutritionClientAge = 43 }
            };
        }

        public SportNutritionClient AddSportNutritionClient(SportNutritionClient sportNutritionClient)
        {
            sportNutritionClient.SportNutritionClientID = _sportNutritionClientList.Max(spnc => spnc.SportNutritionClientID) + 1;
            _sportNutritionClientList.Add(sportNutritionClient);
            return sportNutritionClient;
        }

        public SportNutritionClient DeleteSportNutritionClient(int sportNutritionClientId)
        {
            SportNutritionClient sportNutritionClient = _sportNutritionClientList.FirstOrDefault(spnc => spnc.SportNutritionClientID == sportNutritionClientId);
            if (sportNutritionClient != null)
            {
                _sportNutritionClientList.Remove(sportNutritionClient);
            }

            return sportNutritionClient;
        }

        public IEnumerable<SportNutritionClient> GetAllSportNutritionClients()
        {
            return _sportNutritionClientList;
        }

        public SportNutritionClient GetSportNutritionClient(int sportNutritionClientId)
        {
            return _sportNutritionClientList.FirstOrDefault(spnc => spnc.SportNutritionClientID == sportNutritionClientId);
        }

        public SportNutritionClient UpdateSportNutritionClient(SportNutritionClient sportNutritionClientChanges)
        {
            SportNutritionClient sportNutritionClient = _sportNutritionClientList.FirstOrDefault(spnc => spnc.SportNutritionClientID == sportNutritionClientChanges.SportNutritionClientID);
            if (sportNutritionClient != null)
            {
                sportNutritionClient.SportNutritionClientName = sportNutritionClientChanges.SportNutritionClientName;
                sportNutritionClient.SportNutritionClientCity = sportNutritionClientChanges.SportNutritionClientCity;
                sportNutritionClient.SportNutritionClientGender = sportNutritionClientChanges.SportNutritionClientGender;
                sportNutritionClient.SportNutritionClientAge = sportNutritionClientChanges.SportNutritionClientAge;
            }

            return sportNutritionClient;
        }
    }
}
