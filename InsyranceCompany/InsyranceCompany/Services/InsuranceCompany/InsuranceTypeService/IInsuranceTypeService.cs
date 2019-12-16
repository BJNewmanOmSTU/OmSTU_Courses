using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany.InsuranceTypeService
{
	public interface IInsuranceTypeService
	{
		public void CreateInsuranceType(InsuranceType type);
		public Task<InsuranceType> GetInsuranceType(int id);
		public List<InsuranceType> GetListInsuranceType();
		public void DeleteInsuranceType(InsuranceType type);
		public Task<InsuranceType> DeleteInsuranceType(int id);		
	}
}
