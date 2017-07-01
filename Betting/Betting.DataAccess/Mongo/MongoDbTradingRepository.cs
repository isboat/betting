using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.DataObjects;
using Betting.Interfaces.DataAccess;

namespace Betting.DataAccess.Mongo
{
    public class MongoDbTradingRepository: ITradingRepository
    {
        public int CreateOrUpdateTournament(Tournament tournament)
        {
            return 1;
        }

        public List<Tournament> GetTournaments(Dictionary<string, string> searchTags)
        {
            throw new NotImplementedException();
        }

        public List<ContextCategory> GetContextCategories(Dictionary<string, string> searchTags)
        {
            throw new NotImplementedException();
        }
    }
}
