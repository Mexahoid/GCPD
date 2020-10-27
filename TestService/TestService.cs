using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using ModelsLibrary;

namespace TestLibrary
{
    public class TestService : ICTService
    {
        List<CompanyTypeModel> res = new List<CompanyTypeModel>();

        public TestService()
        {
            for (int i = 0; i < 18; i++)
            {
                res.Add(new CompanyTypeModel
                {
                    Company = $"Одиночный тестовый тип {i + 1}",
                    ID = i
                });
            }
        }


        public PagedResult<CompanyTypeModel> GetCTs(int id = -1)
        {

            var rr = new PagedResult<CompanyTypeModel>();
            List<CompanyTypeModel> tres = new List<CompanyTypeModel>();

            if (id == -1)
                tres = res;
            else
                foreach (var item in res)
                {
                    if (item.ID == id)
                    {
                        tres.Add(item);
                        break;
                    }
                }


            rr.Page = tres.ToArray();
            rr.PageCount = 1;
            return rr;

        }


        public PagedResult<CompanyTypeModel> GetPagedCTs(int page, int pagecount)
        {
            var rr = new PagedResult<CompanyTypeModel>();
            var ttx = res.Skip((page - 1) * pagecount).Take(pagecount).ToArray();
            rr.Page = ttx;
            rr.PageCount = res.Count() / pagecount + 1;
            return rr;
        }
    }
}
