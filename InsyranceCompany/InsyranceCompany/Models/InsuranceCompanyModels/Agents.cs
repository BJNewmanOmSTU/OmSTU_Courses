using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsyranceCompany
{
    public partial class Agents
    {
        public Agents()
        {
            Contracts = new HashSet<Contracts>();
        }

        public int AgentId { get; set; }
        public int FilialId { get; set; }
		public string AName { get; set; }
        public string APatronymic { get; set; }
        public string ASurname { get; set; }
        public string AAddress { get; set; }
        public string APhone { get; set; }
        public decimal? Salary { get; set; }

        public virtual Filials Filial { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
