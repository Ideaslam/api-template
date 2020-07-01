using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.SearchCriteria;
using Orchestrator.Common.Contract;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppResourceController : ControllerBase
    {

        private readonly IAppResourceOrchestrator appResourceOrchestrator; 

        public AppResourceController (
            IAppResourceOrchestrator _appResourceOrchestrator)
        {
            appResourceOrchestrator = _appResourceOrchestrator;
        }



        // GET: api/AppResource
        [HttpGet]
        public  ActionResult<IEnumerable<AppResource>>  Get(AppResourceSearchCriteria appResourceSearchCriteria)
        {
            return Ok( appResourceOrchestrator.Get(appResourceSearchCriteria));
        }

       
        // POST: api/AppResource
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AppResource/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
