using Domain.Entity.Common;
using Model.DTOs;
using Model.SearchCriteria;
using Model.SearchResult;
using Model.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestrator.Common.Contract
{
    public interface ICityOrchestrator
    {
           CitySearchResult Get(CitySearchCriteria citySearchCriteria);
           ExecutionResponse<bool> Delete(int id);
        ExecutionResponse<CityDTO> Create(City city);
        ExecutionResponse<CityDTO> Update(City city);
    }
}
