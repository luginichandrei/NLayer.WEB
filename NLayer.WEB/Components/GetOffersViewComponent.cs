using AutoMapper;
using NLayer.BLL.DTO;
using NLayer.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayer.WEB.Components
{
    public class GetOffersViewComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentCategory { get; set; }
    }

    //public string Invoke()
    //{
    //    IEnumerable<OfferDTO> offerDtos = offerService.GetOffers();
    //    var mapperOffer = new MapperConfiguration(cfg => cfg.CreateMap<OfferDTO, GetOffersViewModel>()).CreateMapper();
    //    var offers = mapperOffer.Map<IEnumerable<OfferDTO>, List<GetOffersViewModel>>(offerDtos);

    //    return offers;
    //}
}