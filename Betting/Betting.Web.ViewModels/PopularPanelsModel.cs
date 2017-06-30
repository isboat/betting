using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.ViewModels;

namespace Betting.Web.ViewModels
{
    public class PopularPanelsModel
    {
        public PopularPanelsModel()
        {
            this.Panels = new List<PanelModel>();
        }

        public List<PanelModel> Panels { get; set; }
    }
}
