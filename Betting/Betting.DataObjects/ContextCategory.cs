using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.DataObjects
{
    public class ContextCategory
    {
        public string Id { get; set; }

        public string TournamentId { get; set; }


        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Ended => this.EndedOn.HasValue;

        public DateTime? EndedOn { get; set; }
    }
}
