using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BLL.DTO
{
    public class CustomerOfferDTO
    {
        public int Id { get; set; }

        public string Order { get; set; }

        public string TimeRealization { get; set; }

        public int Price { get; set; }

        public int CustomerID { get; set; }

    }
}
