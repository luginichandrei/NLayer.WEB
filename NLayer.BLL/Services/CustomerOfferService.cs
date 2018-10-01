using AutoMapper;
using NLayer.BLL.DTO;
using NLayer.BLL.Infrastructure;
using NLayer.BLL.Interfaces;
using NLayer.DAL.Entites;
using NLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BLL.Services
{
    public class CustomerOfferService : ICustomerOfferService
    {
        IUnitOfWork Database { get; set; }

        public CustomerOfferService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeCustomerOffer(CustomerOfferDTO customerOfferDto)
        {
            CustomerOffer customerOffers = Database.CustomerOffers.Get(customerOfferDto.Id);

            
            CustomerOffer customerOffer = new CustomerOffer
            {
                
                Order = customerOfferDto.Order,
                TimeRealization = customerOfferDto.TimeRealization,
                CustomerID = customerOfferDto.CustomerID,
                Price = customerOfferDto.Price
            };
            Database.CustomerOffers.Create(customerOffer);
            Database.Save();
        }

        public IEnumerable<CustomerOfferDTO> GetCustomerOffer()
        {
            
            var mapper = new MapperConfiguration(x => x.CreateMap<CustomerOffer, CustomerOfferDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CustomerOffer>, List<CustomerOfferDTO>>(Database.CustomerOffers.GetAll());
        }

        public CustomerOfferDTO GetCustomerOffer(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set id Customer", "");
            var customer = Database.CustomerOffers.Get(id.Value);
            if (customer == null)
                throw new ValidationException("Customer not find", "");

            return new CustomerOfferDTO { Id = customer.Id, Order=customer.Order, Price=customer.Price, TimeRealization=customer.TimeRealization, CustomerID=customer.Id };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
