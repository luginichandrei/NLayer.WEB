using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DAL.Entites
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentCategory { get; set; }
        public Category Category { get; set; }
    }
}
