using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsyranceCompany.Services.InsuranceCompany.InsuranceTypeService
{
	public class InsuranceTypeService : IInsuranceTypeService
	{
		private InsuranceCompanyContext _context;

		public InsuranceTypeService(InsuranceCompanyContext context)
		{
			_context = context;
		}

		public async void CreateInsuranceType(InsuranceType type)
		{
			await _context.InsuranceType.AddAsync(type);
			await _context.SaveChangesAsync();
		}

		public void DeleteInsuranceType(InsuranceType type)
		{
			_context.InsuranceType.Remove(type);
		}

		public async void DeleteInsuranceType(int id)
		{
			try
			{
				InsuranceType type = await _context.InsuranceType.FindAsync(id);
				_context.InsuranceType.Remove(type);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{

			}
		}

		public async Task<InsuranceType> GetInsuranceType(int id)
		{
			try
			{
				return await _context.InsuranceType.FindAsync(id);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<InsuranceType> GetListInsuranceType()
		{
			return _context.InsuranceType.ToList();
		}
	}
}
