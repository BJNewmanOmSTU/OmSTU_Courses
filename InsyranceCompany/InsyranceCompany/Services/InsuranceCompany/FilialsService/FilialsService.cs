using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany.FilialsService
{
	public class FilialsService : IFilialsService
	{
		private InsuranceCompanyContext _context;

		public FilialsService(InsuranceCompanyContext context)
		{
			_context = context;
		}

		public async void CreateFilial(Filials filial)
		{
			await _context.Filials.AddAsync(filial);
			await _context.SaveChangesAsync();
		}

		public async void DeleteFilial(int id)
		{
			try
			{
				Filials filial = await _context.Filials.FindAsync(id);
				_context.Remove(filial);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{

			}
		}

		public async void DeleteFilial(Filials filial)
		{
			_context.Remove(filial);
			await _context.SaveChangesAsync();
		}

		public async Task<Filials> GetFilial(int id)
		{
			try
			{
				return await _context.Filials.FindAsync(id);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<Filials> GetFilials()
		{
			return _context.Filials.ToList();
		}
	}
}
