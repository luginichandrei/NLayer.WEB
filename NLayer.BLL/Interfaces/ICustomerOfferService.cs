using NLayer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BLL.Interfaces
{
    public interface ICustomerOfferService
    {
        void MakeCustomerOffer(CustomerOfferDTO customerOfferDTO);
        CustomerOfferDTO GetCustomerOffer(int? id);
        IEnumerable<CustomerOfferDTO> GetCustomerOffer();
        void Dispose();
    }
}
