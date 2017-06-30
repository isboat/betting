using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.DataObjects;
using Betting.Interfaces.DataAccess;
using Betting.Interfaces.ModelServices;
using Betting.ViewModels;
using Betting.ViewModels.SearchTags;

namespace Betting.Core.ModelServices
{
    public class TradingContentService: ITradingContentService
    {
        private readonly ITradingRepository tradingRepository;

        public TradingContentService(ITradingRepository tradingRepository)
        {
            this.tradingRepository = tradingRepository;
        }

        public BaseResponse CreateOrUpdateTournament(TournamentModel model)
        {
            var dbResult = tradingRepository.CreateOrUpdateTournament(
                    new Tournament {Name = model.Name, Id = model.Id, CreatedOn = model.CreatedOn});

            return new BaseResponse { Success = true};
        }

        public List<TournamentModel> GetTournaments(SearchTagsView searchTags)
        {
            var tournaments = this.tradingRepository.GetTournaments(MapSearchTags(searchTags));

            return tournaments.Select(t => this.CreateViewModel(t, this.CreateTournamentModel)).ToList();
        }

        public TournamentModel GetTournament(string id)
        {
            var search = new SearchTagsView();
            search.Tags.Add(new IdSearchTag(id));

            var list = this.GetTournaments(search);

            return list.FirstOrDefault();
        }

        public TournamentDetailsModel GetTournamentDetails(string id)
        {
            var response = new TournamentDetailsModel();

            var tournament = this.GetTournament(id);
            response.Id = tournament.Id;
            response.Name = tournament.Name;

            var contextCats = this.GetContextCategories(tournament.Id);
        }

        public List<ContextCategoryView> GetContextCategories(string tournamentId)
        {
            throw new NotImplementedException();
        }

        public List<ContextModel> GetContexts(string contextCatId)
        {
            throw new NotImplementedException();
        }

        #region Privates
        
        private T CreateViewModel<T,TS>(TS domObj, Func<TS, T> func)
        {
            return func(domObj);
        }

        private TournamentModel CreateTournamentModel(Tournament model)
        {
            return new TournamentModel
            {
                Id = model.Id,
                Name = model.Name,
                CreatedOn = model.CreatedOn
            };
        }

        private Dictionary<string, string> MapSearchTags(SearchTagsView searchTags)
        {
            return searchTags.Tags.ToDictionary(tag => tag.Key, tag => tag.Value);
        }

        #endregion
    }
}
