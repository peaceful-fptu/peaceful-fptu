using System;
using System.Collections.Generic;

namespace Project_PRN.Models
{
    public partial class WorkTypeEnvn
    {
        public WorkTypeEnvn()
        {
            DictionaryEnvns = new HashSet<DictionaryEnvn>();
        }

        public int Id { get; set; }
        public string WordType { get; set; } = null!;

        public virtual ICollection<DictionaryEnvn> DictionaryEnvns { get; set; }
    }
}
