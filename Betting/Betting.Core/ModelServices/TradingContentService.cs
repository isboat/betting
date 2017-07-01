using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.DataObjects;
using Betting.Interfaces.DataAccess;
using Betting.Interfaces.ModelServices;
using Betting.ViewModels;

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

            return new BaseResponse { Success = dbResult == 1};
        }

        public List<TournamentModel> GetTournaments(SearchTagsView searchTags)
        {
            var tournaments = this.tradingRepository.GetTournaments(MapSearchTags(searchTags));

            return tournaments.Select(t => this.CreateViewModel(t, this.CreateTournamentModel)).ToList();
        }

        public TournamentModel GetTournament(string id)
        {
            var search = new SearchTagsView();
            search.Tags.Add(SearchBy.IdTag, id);

            var list = this.GetTournaments(search);

            return list.FirstOrDefault();
        }

        public TournamentDetailsModel GetTournamentDetails(string id)
        {
            var response = new TournamentDetailsModel();

            var tournament = this.GetTournament(id);
            response.Id = tournament.Id;
            response.Name = tournament.Name;

            var catSearch = new SearchTagsView();
            catSearch.Tags.Add(SearchBy.Tid, id);

            response.ContextCategories = this.GetContextCategories(catSearch);

            return response;
        }

        public string AddOrUpdateContextCategory(ContextCategoryView model)
        {
            var newId =
                tradingRepository.AddOrUpdateContextCategory(
                    new ContextCategory
                    {
                        Id = model.Id,
                        TournamentId = model.TournamentId,
                        Name = model.Name,
                        CreatedOn = model.CreatedOn,
                        EndedOn = model.EndedOn
                    });

            return newId;
        }

        public List<ContextCategoryView> GetContextCategories(SearchTagsView searchTags)
        {
            var cats = this.tradingRepository.GetContextCategories(searchTags.Tags);
            return cats.Select(c => this.CreateViewModel(c, this.CreateCategoryModel)).ToList();
        }

        public ContextCategoryDetails GetContextCategoryDetails(string id)
        {
            var searchTag = new SearchTagsView();
            searchTag.Tags.Add(SearchBy.IdTag, id);

            var cat = this.GetContextCategories(searchTag).FirstOrDefault();

            if (cat == null)
            {
                return null;
            }

            var response = new ContextCategoryDetails
            {
                Id = cat.Id,
                TournamentId = cat.TournamentId,
                Name = cat.Name
            };

            return response;
        }

        public List<ContextModel> GetContexts(SearchTagsView searchTags)
        {
            throw new NotImplementedException();
        }

        #region Privates
        
        private T CreateViewModel<T,TS>(TS domObj, Func<TS, T> func)
        {
            return func(domObj);
        }

        private ContextCategoryView CreateCategoryModel(ContextCategory model)
        {
            return new ContextCategoryView
            {
                Id = model.Id,
                Name = model.Name,
                CreatedOn = model.CreatedOn
            };
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
