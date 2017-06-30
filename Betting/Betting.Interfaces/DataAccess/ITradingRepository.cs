using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.DataObjects;

namespace Betting.Interfaces.DataAccess
{
    public interface ITradingRepository
    {
        int CreateOrUpdateTournament(Tournament tournament);

        List<Tournament> GetTournaments(Dictionary<string, string> searchTags);

        List<ContextCategory> GetContextCategories(string tournamentId);
    }
}
