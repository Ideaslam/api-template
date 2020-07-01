using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.SearchCriteria;
using Model.SearchResult;
using Model.Support;
using Orchestrator.Common.Contract;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly ICityOrchestrator cityOrchestrator  ; 

        public CityController (
            ICityOrchestrator  _cityOrchestrator)
        {
            cityOrchestrator = _cityOrchestrator;
        }


 
        [HttpPost]
        
        public  ActionResult<CitySearchResult>  Get(CitySearchCriteria  citySearchCriteria)
        {
            return Ok(cityOrchestrator.Get(citySearchCriteria));
        }


        [HttpPost]
        
        public ActionResult<CitySearchResult> Create(City city)
        {
            return Ok(cityOrchestrator.Create(city));
        }

        [HttpPost]
       
        public ActionResult<CitySearchResult> Update(City city)
        {
            return Ok(cityOrchestrator.Update(city));
        }



        [HttpPost]
        
        public ActionResult<ExecutionResponse<bool>> Delete([FromBody] CitySearchCriteria searchCriteria)
        {
            var id = searchCriteria.Id ?? 0; 
             return  Ok(cityOrchestrator.Delete(id));
        }
    }
}
