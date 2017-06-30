using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels
{
    public class TournamentModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
    }

    public class TournamentDetailsModel : TournamentModel
    {

        public List<ContextCategoryView> ContextCategories { get; set; }
    }
}
