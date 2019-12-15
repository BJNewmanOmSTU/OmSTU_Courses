using System;
using System.Collections.Generic;

namespace InsyranceCompany
{
    public partial class Filials
    {
        public Filials()
        {
            Agents = new HashSet<Agents>();
        }

        public int FilialId { get; set; }
        public string FilialAddress { get; set; }
        public string FilialPhone { get; set; }

        public virtual ICollection<Agents> Agents { get; set; }
    }
}
