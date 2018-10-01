using AutoMapper;
using NLayer.BLL.DTO;
using NLayer.BLL.Interfaces;
using NLayer.DAL.Entites;
using NLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        IUnitOfWork Database { get; set; }

        public CustomerService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeCustomer(CustomerDTO customerDto)
        {
            Customer customers = Database.Customers.Get(customerDto.Id);

           
            Customer customer = new Customer
            {
                Id = customerDto.Id,
                FirstName=customerDto.FirstName,
                LastName=customerDto.LastName,
                PhoneNumber= customerDto.PhoneNumber

            };
            Database.Customers.Create(customer);
            Database.Save();
        }

        public IEnumerable<CustomerDTO> GetCustomers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(x => x.CreateMap<Customer, CustomerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(Database.Customers.GetAll());
        }

        public CustomerDTO GetCustomer(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set id Customer");
            var customer = Database.Customers.Get(id.Value);
            if (customer == null)
                throw new ValidationException("Customer not find");

            return new CustomerDTO { Id = customer.Id, FirstName=customer.FirstName, LastName=customer.LastName, PhoneNumber=customer.PhoneNumber};
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
