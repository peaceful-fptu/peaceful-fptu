using System;
using System.Collections.Generic;

namespace Project_PRN.Models
{
    public partial class WorkTypeVnen
    {
        public WorkTypeVnen()
        {
            DictionaryVnens = new HashSet<DictionaryVnen>();
        }

        public int Id { get; set; }
        public string WordType { get; set; } = null!;

        public virtual ICollection<DictionaryVnen> DictionaryVnens { get; set; }
    }
}
