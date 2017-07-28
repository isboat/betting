using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels
{
    public class ContextModel : BaseViewModel
    {

        public ContextModel()
        {
            this.Selections = new List<SelectionModel>();
            this.Teams = new List<TeamModel>();
        }

        public string CatId { get; set; }

        /// <summary>
        /// Eg Adisco v Prem v Presec
        /// </summary>
        public string Label { get; set; }

        public List<TeamModel> Teams { get; set; }

        public List<SelectionModel> Selections { get; set; }
    }
}
