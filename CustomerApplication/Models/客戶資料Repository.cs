using System;
using System.Linq;
using System.Collections.Generic;
	
namespace CustomerApplication.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(a => a.是否已刪除 == false);
        }

        public override void Add(客戶資料 entity)
        {
            entity.是否已刪除 = false;
            base.Add(entity);
        }

        public override void Delete(客戶資料 entity)
        {
            entity.是否已刪除 = true;
        }

        public 客戶資料 Find(int id)
        {
            return this.All().FirstOrDefault(a => a.Id == id);
        }

        public void Update(客戶資料 entity)
        {
            ((CustomerEntities)base.UnitOfWork.Context).Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
	}

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}