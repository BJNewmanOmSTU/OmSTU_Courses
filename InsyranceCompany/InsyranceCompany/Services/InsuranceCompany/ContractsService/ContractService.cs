using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany.ContractsService
{
	public class ContractService : IContractService
	{
		private InsuranceCompanyContext _context;

		public ContractService(InsuranceCompanyContext context)
		{
			_context = context;
		}

		public async void CreateContract(Contracts contracts)
		{
			await _context.Contracts.AddAsync(contracts);
			await _context.SaveChangesAsync();
		}

		public async void DeleteContract(int id)
		{
			try
			{
				Contracts contract = await _context.Contracts.FindAsync(id);
				_context.Contracts.Remove(contract);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{

			}
		}

		public async void DeleteContract(Contracts contract)
		{
			_context.Contracts.Remove(contract);
			await _context.SaveChangesAsync();
		}

		public async Task<Contracts> GetContract(int id)
		{
			try
			{
				return await _context.Contracts.FindAsync(id);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<Contracts> GetContracts()
		{
			return _context.Contracts.ToList();
		}
	}
}
