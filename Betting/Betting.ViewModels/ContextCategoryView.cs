using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels
{
    public class ContextCategoryView
    {
        public string Id { get; set; }

        public string TournamentId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Ended => this.EndedOn.HasValue;

        public DateTime? EndedOn { get; set; }
    }

    public class ContextCategoryDetails: ContextCategoryView
    {
        public ContextCategoryDetails()
        {
            Contexts = new List<ContextModel>();
        }

        public List<ContextModel> Contexts { get; set; }
    }
}
