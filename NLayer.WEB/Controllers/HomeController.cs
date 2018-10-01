using AutoMapper;

using NLayer.BLL.DTO;
using NLayer.BLL.Interfaces;
using NLayer.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayer.WEB.Controllers
{
    public class HomeController : Controller
    {
        ICustomerService customerService;
        ICustomerOfferService customerOfferService;
        IOfferService offerService;
        public HomeController(ICustomerService serv, ICustomerOfferService servOfferCust, IOfferService servOffer)
        {
            customerService = serv;
            customerOfferService = servOfferCust;
            offerService = servOffer;
        }
        public ActionResult Index()
        {
            CustomerDTO customerDtos = customerService.GetCustomer(1);
            var mapper = new MapperConfiguration(x => x.CreateMap<CustomerDTO, CustomerViewModel>()).CreateMapper();
            var customer = mapper.Map<CustomerViewModel>(customerDtos);
            return View(customer);
        }

        public ActionResult MyOrder()
        {
            IEnumerable<CustomerOfferDTO> customerOfferDtos = customerOfferService.GetCustomerOffer();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CustomerOfferDTO, CustomerOfferViewModel>()).CreateMapper();
            var customerOffer = mapper.Map<IEnumerable<CustomerOfferDTO>, List<CustomerOfferViewModel>>(customerOfferDtos);
            var customerOffers = customerOffer.TakeWhile(x => x.CustomerID == 1);
            return View(customerOffers);
        }

        public ActionResult MakeCustomerOffer(int? id)
        {
            try
            {
                CustomerDTO customer = customerService.GetCustomer(id);
                var order = new CustomerOfferViewModel { CustomerID = customer.Id };

                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult GetOffers (GetOffersViewModel model)
        {
            IEnumerable<OfferDTO> offerDtos = offerService.GetOffers();
            var mapperOffer = new MapperConfiguration(cfg => cfg.CreateMap<OfferDTO, GetOffersViewModel>()).CreateMapper();
            var offers = mapperOffer.Map<IEnumerable<OfferDTO>, List<GetOffersViewModel>>(offerDtos);

            return PartialView(offers);
        } 

        [HttpPost]
        public ActionResult MakeCustomerOffer(CustomerOfferViewModel model)
        {
            try
            {
                var customerOfferDto = new CustomerOfferDTO {  CustomerID= 1, Order = model.Order, Price = model.Price, TimeRealization = model.TimeRealization };
                customerOfferService.MakeCustomerOffer(customerOfferDto);
                return Content("<h2>Your order is successfully completed</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            customerService.Dispose();
            base.Dispose(disposing);
        }






        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}