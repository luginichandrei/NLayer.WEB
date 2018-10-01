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
    public class OfferService : IOfferService
    {
        IUnitOfWork Database { get; set; }

        public OfferService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOffer(OfferDTO offerDto)
        {
            Offer offers = Database.Offers.Get(offerDto.Id);

            
            Offer offer = new Offer
            {
                Id = offerDto.Id,
                Name =offerDto.Name,
                CurrentCategory =offerDto.CurrentCategory               

            };
            Database.Offers.Create(offer);
            Database.Save();
        }

        public IEnumerable<OfferDTO> GetOffers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(x => x.CreateMap<Offer, OfferDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Offer>, List<OfferDTO>>(Database.Offers.GetAll());
        }

        public OfferDTO GetOffer(int? id)
        {
            if (id == null)
                throw new ValidationException("Not set id Offer");
            var offer = Database.Offers.Get(id.Value);
            if (offer == null)
                throw new ValidationException("Customer not find");

            return new OfferDTO { Id = offer.Id, Name=offer.Name, CurrentCategory=offer.CurrentCategory };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }


}
