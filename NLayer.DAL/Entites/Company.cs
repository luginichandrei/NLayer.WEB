using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DAL.Entites
{
    public class Company
    {

        public int Id { get; set; }
       
        public string Name { get; set; }

        public string Adress { get; set; }

       
        public ICollection<Executor> Executors { get; set; }
    }
}
