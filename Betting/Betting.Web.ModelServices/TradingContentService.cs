using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.Interfaces.ModelServices;
using Betting.Web.ViewModels;

namespace Betting.Web.ModelServices
{
    public class TradingContentService: ITradingContentService
    {
        public List<TournamentView> GetTournaments()
        {
            return new List<TournamentView>();
        }

        public List<ContextCategoryView> GetContextCategories(string tournamentId)
        {
            throw new NotImplementedException();
        }

        public List<ContextView> GetContexts(string contextCatId)
        {
            throw new NotImplementedException();
        }

        public PopularPanelsView GetPopularPanels()
        {
            var panels = new PopularPanelsView();

            for (int i = 0; i < 5; i++)
            {
                panels.Panels.Add(new PanelView
                {
                    Name = "Panel " + i
                });
            }

            return panels;
        }
    }
}
