using System;
using System.Collections.Generic;

namespace InsyranceCompany
{
    public partial class Clients
    {
        public Clients()
        {
            Contracts = new HashSet<Contracts>();
        }

        public int ClientId { get; set; }
        public string CName { get; set; }
        public string CPatronymic { get; set; }
        public string CSurname { get; set; }
        public string BirthYear { get; set; }
        public string CPhone { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
