using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany.AgentsService
{
	public interface IAgentService
	{
		public void CreateAgent(Agents agent);
		public Task<Agents> GetAgent(int id);

		public List<Agents> GetAgents();

		public void DeleteAgent(int id);
		public void DeleteAgent(Agents agent);
	}
}
