using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DAL.Entites
{
    public class Executor
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
        
        public int PhoneNumber { get; set; }
                      
        public int CurrentCompanyId { get; set; }
      
        public Company CurrentCompany { get; set; }
    }
}
