using Ninject.Modules;
using NLayer.BLL.Interfaces;
using NLayer.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace NLayer.WEB.Util
{

    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerOfferService>().To<CustomerOfferService>();
            Bind<ICustomerService>().To<CustomerService>();
            Bind<IOfferService>().To<OfferService>();
        }
    }
}