using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Web.ViewModels
{
    public class PopularPanelsView
    {
        public PopularPanelsView()
        {
            this.Panels = new List<PanelView>();
        }

        public List<PanelView> Panels { get; set; }
    }
}
