using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Web.ViewModels
{
    public class PanelView
    {
        public string Name { get; set; }

        public bool IsCollapsible { get; set; }

        public bool Collapsed { get; set; }
    }
}
