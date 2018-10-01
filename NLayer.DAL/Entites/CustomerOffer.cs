using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NLayer.DAL.Entites
{
    public class CustomerOffer
    {
        public CustomerOffer() { }
        public int Id { get; set; }

        public string Order { get; set; }
       
        public string TimeRealization { get; set; }
        
        public int Price { get; set; }

        public int CustomerID { get; set; }
        
        public Customer CurentCustomer { get; set; }
    }
}
