﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModels
{
    public class SelectionModel
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Ended => this.EndedOn.HasValue;

        public DateTime? EndedOn { get; set; }
    }
}
