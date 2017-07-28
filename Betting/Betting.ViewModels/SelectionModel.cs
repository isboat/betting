using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels
{
    public class SelectionModel : BaseViewModel
    {
        public string Cid { get; set; }

        public string Label { get; set; }

        public int FirstNum { get; set; }

        public int SecondNum { get; set; }
    }
}
