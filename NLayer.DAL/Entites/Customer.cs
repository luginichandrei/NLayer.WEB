using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NLayer.DAL.Entites
{
    public class Customer
    {
        public Customer() { }
        public int Id { get; set; }
               
        public string FirstName { get; set; }
                
        public string LastName { get; set; }
                
        public string PhoneNumber { get; set; }
        
        public ICollection<Customer> CustomersOffers { get; set; }
    }
}
