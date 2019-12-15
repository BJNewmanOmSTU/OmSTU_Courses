using InsyranceCompany.Services.InsuranceCompany.AgentsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany
{
	public class AgentsController : IAgentService
	{
		private InsuranceCompanyContext _context;

		public AgentsController(InsuranceCompanyContext context)
		{
			_context = context;
		}

		public async void CreateAgent(Agents agent)
		{
			await _context.Agents.AddAsync(agent);
			await _context.SaveChangesAsync();
		}

		public async Task<Agents> GetAgent(int id)
		{
			try
			{
				return await _context.Agents.FindAsync(id);
			}
			catch(Exception)
			{
				return null;
			}			
		}

		public List<Agents> GetAgents()
		{
			return _context.Agents.ToList();
		}

		public async void DeleteAgent(int id)
		{
			try
			{
				Agents agent = await _context.Agents.FindAsync(id);
				_context.Agents.Remove(agent);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				
			}
			
		}

		public void DeleteAgent(Agents agent)
		{
			_context.Agents.Remove(agent);
		}
	}
}
