using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels
{
    public class SearchTagsView
    {
        public SearchTagsView()
        {
            this.Tags = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Tags { get; set; }
    }

    public static class SearchBy
    {
        public const string IdTag = "id";
        public const string Tid = "tid";
    }
}
