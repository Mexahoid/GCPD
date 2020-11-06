using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLibrary;


namespace GCPD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaborExchangeController : ControllerBase
    {
        private readonly ICompanyTypeService _service = new TestLibrary.TestService();
        private readonly ILogger<LaborExchangeController> _logger;

        public LaborExchangeController(ILogger<LaborExchangeController> logger)
        {
            _logger = logger;
        }

        [HttpGet] 
        [Route("")]
        public object[] CompanyTypesGetAll()
        {   
            
            PagedResult<CompanyTypeModel> t = _service.CompanyTypesGetAll();
            List<object> objs = new List<object>
            {
                t.PageCount, 
                t.Page
            };
            return objs.ToArray();
        }

        [HttpGet]
        [Route("id/{id:int}")]
        public object[] CompanyTypesGetById(int id)
        {
            var t = _service.CompanyTypesGetById(id);
            List<object> objs = new List<object>
            {
                t.PageCount, 
                t.Page
            };
            return objs.ToArray();
        }

        [HttpGet]
        [Route("page/{page:int}/pagecount/{pagecount:int}")]
        public object[] CompanyTypesGetByPageAndPagecount(int page, int pagecount)
        {
            var t = _service.CompanyTypesGetByPageAndPagecount(page, pagecount);
            List<object> objs = new List<object>
            {
                t.PageCount, 
                t.Page
            };
            return objs.ToArray();
        }
    }
}
