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
            this.Tags = new List<ISearchTag>();
        }

        public List<ISearchTag> Tags { get; set; }
    }

    public interface ISearchTag
    {
        string Key { get; }

        string Value { get; set; }
    }
}
