using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.Web.ViewModels;

namespace Betting.Interfaces.ModelServices
{
    public interface IWebTradingContentService
    {
        PopularPanelsModel GetPopularPanels();
    }
}
