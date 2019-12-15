using System;
using System.Collections.Generic;

namespace InsyranceCompany
{
    public partial class Contracts
    {
        public int ContractId { get; set; }
        public int InsuranceTypeId { get; set; }
        public DateTime? DateConclusion { get; set; }
        public decimal? Payment { get; set; }
        public int? AgentId { get; set; }
        public int ClientId { get; set; }

        public virtual Agents Agent { get; set; }
        public virtual Clients Client { get; set; }
        public virtual InsuranceType InsuranceType { get; set; }
    }
}
