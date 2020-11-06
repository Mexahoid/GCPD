using System;
using ModelsLibrary;

namespace Interfaces
{

    public interface ICompanyTypeService
    {
        PagedResult<CompanyTypeModel> CompanyTypesGetById(int id);

        PagedResult<CompanyTypeModel> CompanyTypesGetAll();

        PagedResult<CompanyTypeModel> CompanyTypesGetByPageAndPagecount(int page, int pagecount);
    }
}
