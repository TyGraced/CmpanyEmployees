using Microsoft.AspNetCore.Http;
using Shared.RequestFeatures;

namespace Entities.LinkModels
{
    public record LinkParmeters(EmployeeParameters EmployeeParameters, HttpContext Context);
    public record LinkCompanyParmeters(CompanyParameters CompanyParameters, HttpContext Context);
}
