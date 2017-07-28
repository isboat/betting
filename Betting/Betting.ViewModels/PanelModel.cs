using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels
{
    public class PanelModel
    {
        public PanelModel()
        {
            this.ContextCategory = new List<ContextCategoryView>();
        }
        public string Name { get; set; }

        public bool IsCollapsible { get; set; }

        public bool Collapsed { get; set; }

        public List<ContextCategoryView> ContextCategory { get; set; }
    }
}
