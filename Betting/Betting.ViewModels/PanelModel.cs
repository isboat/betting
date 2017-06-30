using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels
{
    public class PanelModel
    {
        public string Name { get; set; }

        public bool IsCollapsible { get; set; }

        public bool Collapsed { get; set; }

        public List<ContextModel> Contexts { get; set; }
    }
}
