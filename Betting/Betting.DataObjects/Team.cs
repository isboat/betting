using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.DataObjects
{
    public class Team: BaseDomainModel
    {
        public string Cid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
