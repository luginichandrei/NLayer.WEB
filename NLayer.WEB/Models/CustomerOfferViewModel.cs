using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayer.WEB.Models
{
    public class CustomerOfferViewModel
    {
        public int Id { get; set; }
        public string Order { get; set; }
        public string TimeRealization { get; set; }
        public int Price { get; set; }
        public int CustomerID { get; set; }
    }
}