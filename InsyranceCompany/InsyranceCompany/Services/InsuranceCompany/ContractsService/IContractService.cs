using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany.ContractsService
{
	public interface IContractService
	{
		public void CreateContract(Contracts contracts);
		public Task<Contracts> GetContract(int id);
		public List<Contracts> GetContracts();
		public void DeleteContract(int id);
		public void DeleteContract(Contracts contract);
	}
}
