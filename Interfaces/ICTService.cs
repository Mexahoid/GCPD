using System;
using ModelsLibrary;

namespace Interfaces
{

    public interface ICTService
    {
        PagedResult<CompanyTypeModel> GetCTs(int id = -1);

        PagedResult<CompanyTypeModel> GetPagedCTs(int page, int pagecount);
    }
}
