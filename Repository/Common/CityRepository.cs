using Data;
using Data.UnitOfWork;
using Domain.Entity.Common;
using LinqKit;
using Model.SearchCriteria;
using Repository.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Common
{
    public class CityRepository :GenericRepository<City> , ICityRepository
    {
        public CityRepository(IUnitOfWork<ApplicationDbContext> unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable<City> GetAsQueryable(CitySearchCriteria criteria, string includeProperties = "")
        { 
            var outerpredicate = PredicateBuilder.New<City>(true);
            if (criteria.Id != null)
            {

                outerpredicate = outerpredicate.And(d => d.Id == criteria.Id.Value);
            }
            return Get(outerpredicate, includeProperties: includeProperties);

        }
    }
}
