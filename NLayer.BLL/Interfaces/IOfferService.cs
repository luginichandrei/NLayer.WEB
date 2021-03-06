﻿using NLayer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BLL.Interfaces
{
    public interface IOfferService
    {
        void MakeOffer(OfferDTO offerDTO);
        OfferDTO GetOffer(int? id);
        IEnumerable<OfferDTO> GetOffers();
        void Dispose();
    }
}
