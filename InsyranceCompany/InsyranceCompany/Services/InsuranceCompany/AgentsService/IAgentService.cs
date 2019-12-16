using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany.AgentsService
{
	public interface IAgentService
	{
		public Task CreateAgent(Agents agent);
		public Task<Agents> GetAgent(int? id);

		public Task<List<Agents>> GetAgents();

		public Task<Agents> DeleteAgent(int id);
		public void DeleteAgent(Agents agent);
	}
}
