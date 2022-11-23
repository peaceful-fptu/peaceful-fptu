using System;
using System.Collections.Generic;

namespace Project_PRN.Models
{
    public partial class DictionaryEnvn
    {
        public int WordId { get; set; }
        public string Word { get; set; } = null!;
        public string Meaning { get; set; } = null!;
        public int Type { get; set; }

        public virtual WorkTypeEnvn TypeNavigation { get; set; } = null!;
        public String wordString()
        {
            return "Word: " + Word + " Meaning: " + Meaning + " Type: " + TypeNavigation.WordType;
        }
    }
}
