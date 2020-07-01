using Data;
using Domain.Entity.Common;
using Model.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Common.Contract
{
    public  interface IAppResourceRepository : IGenericRepository<AppResource>
    {
        public IQueryable<AppResource> GetAsQueryable(AppResourceSearchCriteria criteria, string includeProperties = "");
    }
}
