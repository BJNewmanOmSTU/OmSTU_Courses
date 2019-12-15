using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany.FilialsService
{
	public interface IFilialsService 
	{
		public void CreateFilial(Filials filial);

		public Task<Filials> GetFilial(int id);

		public List<Filials> GetFilials();

		public void DeleteFilial(int id);

		public void DeleteFilial(Filials filial);
	}
}
