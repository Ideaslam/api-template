using Data;
using Data.UnitOfWork;
using Domain.Entity.Common;
using Model.SearchCriteria;
using Orchestrator.Common.Contract;
using Repository.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orchestrator.Common
{
     
    public  class AppResourceOrchestrator: IAppResourceOrchestrator
    {

        private readonly IUnitOfWork<ApplicationDbContext> unitOfWork;
        private readonly IAppResourceRepository  appResourceRepository;
        public AppResourceOrchestrator(
            IUnitOfWork<ApplicationDbContext> _unitOfWork,
            IAppResourceRepository _appResourceRepository)
        {
            unitOfWork = _unitOfWork;
            appResourceRepository = _appResourceRepository;
        }


        public IEnumerable<AppResource> Get (AppResourceSearchCriteria appResourceSearchCriteria)
        {
           return appResourceRepository.Get().ToList();
        }




    }
}
