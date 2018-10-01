using NLayer.DAL.EF;
using NLayer.DAL.Entites;
using NLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DAL.Repositiries
{
    public class CustomerOfferRepository : IRepository<CustomerOffer>
    {
        private CodeContext db;

        public CustomerOfferRepository(CodeContext context)
        {
            this.db = context;
        }

        public IEnumerable<CustomerOffer> GetAll()
        {
            return db.CustomerOffers;
        }

        public CustomerOffer Get(int id)
        {
            return db.CustomerOffers.Find(id);
        }

        public void Create(CustomerOffer customerOffer)
        {
            db.CustomerOffers.Add(customerOffer);
        }

        public void Update(CustomerOffer customerOffer)
        {
            db.Entry(customerOffer).State = EntityState.Modified;
        }

        public IEnumerable<CustomerOffer> Find(Func<CustomerOffer, Boolean> predicate)
        {
            return db.CustomerOffers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            CustomerOffer customerOffers = db.CustomerOffers.Find(id);
            if (customerOffers != null)
                db.CustomerOffers.Remove(customerOffers);
        }
    }
}
