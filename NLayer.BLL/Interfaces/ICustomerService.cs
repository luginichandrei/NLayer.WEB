using NLayer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BLL.Interfaces
{
    public interface ICustomerService
    {
        void MakeCustomer(CustomerDTO customerDto);
        CustomerDTO GetCustomer(int? id);
        IEnumerable<CustomerDTO> GetCustomers();
        void Dispose();
    }
}
