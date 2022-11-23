using System;
using System.Collections.Generic;

namespace Project_PRN.Models
{
    public partial class DictionaryVnen
    {
        public int WordId { get; set; }
        public string Word { get; set; } = null!;
        public string Meaning { get; set; } = null!;
        public int Type { get; set; }

        public virtual WorkTypeVnen TypeNavigation { get; set; } = null!;
    }
}
