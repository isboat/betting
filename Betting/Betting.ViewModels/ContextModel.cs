using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels
{
    public class ContextModel
    {

        public ContextModel()
        {
            this.Selections = new List<SelectionModel>();
        }

        public string Id { get; set; }

        public string CatId { get; set; }

        /// <summary>
        /// Eg Adisco v Prem v Presec
        /// </summary>
        public string Label { get; set; }

        public List<SelectionModel> Selections { get; set; }
    }
}
