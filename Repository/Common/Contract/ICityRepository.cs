using Data;
using Domain.Entity.Common;
using Model.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Common.Contract
{
    public  interface ICityRepository : IGenericRepository<City>
    {
        public IQueryable<City> GetAsQueryable(CitySearchCriteria criteria, string includeProperties = "");
    }
}
