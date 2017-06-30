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
    }

    public class ContextCategoryDetails: ContextCategoryView
    {
        public List<ContextModel> ContextModels { get; set; }
    }
}
