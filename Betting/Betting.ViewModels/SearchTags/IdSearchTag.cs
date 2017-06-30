using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels.SearchTags
{
    public class IdSearchTag: ISearchTag
    {
        public IdSearchTag(string value)
        {
            this.Value = value;
        }
        public string Key => "id";
        public string Value { get; set; }
    }
}
