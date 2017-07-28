using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.Interfaces.ModelServices;
using Betting.ViewModels;
using Betting.Web.ViewModels;

namespace Betting.Web.ModelServices
{
    public class WebTradingContentService: IWebTradingContentService
    {

        private readonly ITradingContentService tradingContentService;

        public WebTradingContentService(ITradingContentService tradingContentService)
        {
            this.tradingContentService = tradingContentService;
        }

        public PopularPanelsModel GetPopularPanels()
        {
            var tournaments = this.tradingContentService.GetTournaments(new SearchTagsView());
            var panels = new PopularPanelsModel();

            foreach (var tournament in tournaments)
            {
                var panel = new PanelModel
                {
                    Name = tournament.Name
                };

                var catSearch = new SearchTagsView();
                catSearch.Tags.Add(SearchBy.Tid, tournament.Id);
                var categories = this.tradingContentService.GetContextCategories(catSearch);

                foreach (var category in categories)
                {
                    // eg Semi Finals
                    var contextCat = new ContextCategoryDetails
                    {
                        Id = category.Id,
                        Name = category.Name
                    };

                    var contextSearch = new SearchTagsView();
                    contextSearch.Tags.Add(SearchBy.CatId, category.Id);
                    var contexts = this.tradingContentService.GetContexts(contextSearch);

                    foreach (var context in contexts)
                    {
                        var contextView = new ContextModel
                        {
                            Id = context.Id,
                            CatId = category.Id,
                            Label = context.Label
                        };

                        var selectionSearch = new SearchTagsView();
                        selectionSearch.Tags.Add(SearchBy.CId, context.Id);
                        var selections = this.tradingContentService.GetSelections(selectionSearch);
                        contextView.Selections = selections;


                        contextCat.Contexts.Add(contextView);
                    }

                    panel.ContextCategory.Add(contextCat);
                }

                panels.Panels.Add(panel);
            }

            return panels;
        }
    }
}
