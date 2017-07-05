using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.DataObjects
{
    public class Selection : BaseDomainModel
    {
        /// <summary>
        /// Context Id
        /// </summary>
        public string CId { get; set; }

        /// <summary>
        /// Eg Adisco v Prem v Presec
        /// </summary>
        public string Label { get; set; }

        public decimal Price { get; set; }
    }
}
