using Domain.Entity.Common;
using Model.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestrator.Common.Contract
{
    public interface IAppResourceOrchestrator
    {
          IEnumerable<AppResource> Get(AppResourceSearchCriteria appResourceSearchCriteria);
    }
}
