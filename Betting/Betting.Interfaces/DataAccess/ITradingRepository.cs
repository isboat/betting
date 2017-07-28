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

        string AddOrUpdateContextCategory(ContextCategory contextCategory);

        List<ContextCategory> GetContextCategories(Dictionary<string, string> searchTags);

        string AddOrUpdateContext(Context context);

        List<Context> GetContexts(Dictionary<string, string> searchTags);

        List<Selection> GetSelections(Dictionary<string, string> searchTags);

        List<Team> GetTeams(Dictionary<string, string> searchTags);

        string CreateOrUpdateSelection(Selection selection);

        string AddOrUpdateTeam(Team team);

        bool DeleteSelection(string id);
    }
}
