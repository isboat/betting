using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.DataObjects
{
    public class Context
    {
        public string Id { get; set; }

        public string CatId { get; set; }

        /// <summary>
        /// Eg Adisco v Prem v Presec
        /// </summary>
        public string Label { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Ended => this.EndedOn.HasValue;

        public DateTime? EndedOn { get; set; }
    }
}
