using NLayer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BLL.Interfaces
{
    public interface ICompanyService
    {
        void MakeCompany(CompanyDTO companyDTO);
        CompanyDTO GetCompany(int? id);
        IEnumerable<CompanyDTO> GetCompany();
        void Dispose();
    }
}
