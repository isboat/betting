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
        string AddOrUpdateContextCategory(ContextCategoryView model);

        List<ContextCategoryView> GetContextCategories(SearchTagsView searchTags);

        ContextCategoryDetails GetContextCategoryDetails(string id);

        List<ContextModel> GetContexts(SearchTagsView searchTags);

        ContextModel GetContext(string id);

        string AddOrUpdateContext(ContextModel model);

        List<SelectionModel> GetSelections(SearchTagsView searchTags);

    }
}
