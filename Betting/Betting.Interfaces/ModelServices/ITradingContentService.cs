using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.ViewModels;

namespace Betting.Interfaces.ModelServices
{
    public interface ITradingContentService
    {
        BaseResponse CreateOrUpdateTournament(TournamentModel model);

        List<TournamentModel> GetTournaments(SearchTagsView searchTags);

        TournamentModel GetTournament(string id);

        TournamentDetailsModel GetTournamentDetails(string id);

        List<ContextCategoryView> GetContextCategories(SearchTagsView searchTags);

        List<ContextModel> GetContexts(SearchTagsView searchTags);

    }
}
