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
            var panels = new PopularPanelsModel();

            for (int i = 0; i < 5; i++)
            {
                var panel = new PanelModel
                {
                    Name = "Panel " + i,
                    Contexts = new List<ContextModel>()
                };

                var context = new ContextModel { Label = $"College {i} vs College {i + 1} vs College {i+2}"};

                for (int j = 0; j < 3; j++)
                {
                    var sel = new SelectionModel { Label = "College "+j + " win"};
                    context.Selections.Add(sel);
                }
                panel.Contexts.Add(context);

                panels.Panels.Add(panel);
            }

            return panels;
        }
    }
}
