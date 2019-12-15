using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany.ClientsService
{
	public interface IClientService
	{
		public void CreateClient(Clients client);

		public Task<Clients> GetClient(int id);

		public List<Clients> GetClients();

		public void DeleteClient(int id);

		public void DeleteClient(Clients client);


	}
}
