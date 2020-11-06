using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using ModelsLibrary;

namespace TestLibrary
{
    public class TestService : ICompanyTypeService
    {
        private readonly List<CompanyTypeModel> _res = new List<CompanyTypeModel>();

        public TestService()
        {
            for (int i = 0; i < 18; i++)
            {
                _res.Add(new CompanyTypeModel
                {
                    Company = $"Одиночный тестовый тип {i + 20}",
                    ID = i
                });
            }
        }

        public PagedResult<CompanyTypeModel> CompanyTypesGetById(int id)
        {
            var rr = new PagedResult<CompanyTypeModel>();
            List<CompanyTypeModel> tres = new List<CompanyTypeModel>();
            foreach (var item in _res)
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

        public PagedResult<CompanyTypeModel> CompanyTypesGetAll()
        {
            var rr = new PagedResult<CompanyTypeModel>
            {
                Page = _res.ToArray(),
                PageCount = 1
            };
            return rr;

        }

        public PagedResult<CompanyTypeModel> CompanyTypesGetByPageAndPagecount(int page, int pagecount)
        {
            var rr = new PagedResult<CompanyTypeModel>();
            var ttx = _res.Skip((page - 1) * pagecount).Take(pagecount).ToArray();
            rr.Page = ttx;
            rr.PageCount = _res.Count() / pagecount + 1;
            return rr;
        }
    }
}
