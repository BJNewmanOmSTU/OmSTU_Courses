using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany.ClientsService
{
	public class ClientService : IClientService
	{
		private InsuranceCompanyContext _context;

		public ClientService(InsuranceCompanyContext context)
		{
			_context = context;
		}

		public async void CreateClient(Clients client)
		{
			await _context.Clients.AddAsync(client);
			await _context.SaveChangesAsync();
		}

		public async void DeleteClient(int id)
		{
			try
			{
				Clients client = await _context.Clients.FindAsync(id);
				_context.Clients.Remove(client);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{

			}
		}

		public async void DeleteClient(Clients client)
		{
			_context.Clients.Remove(client);
			await _context.SaveChangesAsync();
		}

		public async Task<Clients> GetClient(int id)
		{
			try
			{
				return await _context.Clients.FindAsync(id);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<Clients> GetClients()
		{
			return _context.Clients.ToList();
		}
	}
}
