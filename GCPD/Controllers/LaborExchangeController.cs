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
        private ICTService _service = new TestLibrary.TestService();


        private readonly ILogger<LaborExchangeController> _logger;

        public LaborExchangeController(ILogger<LaborExchangeController> logger)
        {
            _logger = logger;
        }

       // [Route("[abc/def/{ghi}]")]
        [HttpGet] 
        public object[] Get() //int
        {   
            var ss = Request.QueryString;

            var a = ss.Value.Split('?');
            Dictionary<string, string> get = new Dictionary<string, string>();
            if (a.Length == 2)
            {
                var b = a[1].Split('&');
                foreach (var s1 in b)
                {
                    var c = s1.Split('=');
                    if (c.Length != 2)
                        continue;

                    get.Add(c[0], c[1]);
                }
            }
            PagedResult<CompanyTypeModel> t;
            if (get.ContainsKey("id"))
            {
                if (!int.TryParse(get["id"], out int id))
                    return null;

                t = _service.GetCTs(id);
            }
            else if (get.ContainsKey("page") && get.ContainsKey("pagecount"))
            {
                if (!int.TryParse(get["page"], out int page) || !int.TryParse(get["pagecount"], out int pagecount))
                    return null;

                t = _service.GetPagedCTs(page, pagecount);
            }
            else
            {
                t = _service.GetCTs();
            }

            List<object> objs = new List<object> {t.PageCount, t.Page};
            //= new List<object> {t.PageCount, t.Page};
            //return lst.ToArray();
            return objs.ToArray();
        }


    }
}
