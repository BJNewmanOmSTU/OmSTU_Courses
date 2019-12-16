using InsyranceCompany.Services.InsuranceCompany.AgentsService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany
{
	public class AgentService : IAgentService
	{
		private InsuranceCompanyContext _context;

		public AgentService(InsuranceCompanyContext context)
		{
			_context = context;
		}

		public async Task CreateAgent(Agents agent)
		{
			await _context.Agents.AddAsync(agent);
			await _context.SaveChangesAsync();
		}

		public async Task<Agents> GetAgent(int? id)
		{
			try
			{
				if(id != null)
				{
					return await _context.Agents
					.Include(f => f.FilialId)
					.FirstOrDefaultAsync(a => a.AgentId == id);
				}
				else
				{
					return null;
				}				
			}
			catch(Exception)
			{
				return null;
			}			
		}

		public async Task<List<Agents>> GetAgents()
		{
			return await _context.Agents.Include(id => id.FilialId).ToListAsync();
		}

		public async Task<Agents> DeleteAgent(int id)
		{
			try
			{
				Agents agent = await _context.Agents.FindAsync(id);
				_context.Agents.Remove(agent);
				await _context.SaveChangesAsync();

				return agent;
			}
			catch (Exception)
			{
				return null;
			}
			
		}

		public void DeleteAgent(Agents agent)
		{
			_context.Agents.Remove(agent);
		}
	}
}
