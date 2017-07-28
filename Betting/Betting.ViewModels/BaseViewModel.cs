using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels
{
    public class BaseViewModel
    {

        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Ended => this.EndedOn.HasValue;

        public DateTime? EndedOn { get; set; }
    }
}
