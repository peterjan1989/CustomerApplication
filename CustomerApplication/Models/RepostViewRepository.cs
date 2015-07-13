using System;
using System.Linq;
using System.Collections.Generic;
	
namespace CustomerApplication.Models
{   
	public  class RepostViewRepository : EFRepository<RepostView>, IRepostViewRepository
	{

	}

	public  interface IRepostViewRepository : IRepository<RepostView>
	{

	}
}