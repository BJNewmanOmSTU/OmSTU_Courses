using System;
using System.Collections.Generic;

namespace InsyranceCompany
{
    public partial class InsuranceType
    {
        public InsuranceType()
        {
            Contracts = new HashSet<Contracts>();
        }

        public int InsuranceTypeId { get; set; }
        public string InsuranceName { get; set; }
        public decimal? InsuranceSummary { get; set; }
        public string TarifRate { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
