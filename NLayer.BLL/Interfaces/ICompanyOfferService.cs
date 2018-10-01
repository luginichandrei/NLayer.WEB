using NLayer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BLL.Interfaces
{
    public interface ICompanyOfferService
    {
        void MakeCompanyOffer(CompanyOfferDTO companyOfferDTO);
        CompanyOfferDTO GetCompanyOffer(int? id);
        IEnumerable<CompanyOfferDTO> GetCompanyOffer();
        void Dispose();
    }
}
