using InsyranceCompany;
using Ninject.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceCompanyTest.NinjectConfigure
{
	public class NinjectConfig : NinjectModule
	{
		private InsuranceCompanyContext _context;

		public override void Load()
		{
			//Bind<InsuranceCompanyContext>().ToMethod()
		}


		public InsuranceCompanyContext CreateContext()
		{
			if (_context == null)
			{
				DbContextOptions<InsuranceCompanyContext> options = new DbContextOptionsBuilder<InsuranceCompanyContext>().Options;
					//.UseInMemoryDatabase(databaseName: Guid.NewGuid());
				   /*.UseInMemoryDatabase(databaseName: Identity.NewId())
				   .Options;*/
				//_context = new DomainContext(options);
				return _context;
			}
			else
			{
				return _context;
			}
		}
	}
}
