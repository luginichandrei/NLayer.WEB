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
    public class OfferRepository : IRepository<Offer>
    {
        private CodeContext db;

        public OfferRepository(CodeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Offer> GetAll()
        {
            return db.Offers;
        }

        public Offer Get(int id)
        {
            return db.Offers.Find(id);
        }

        public void Create(Offer offer)
        {
            db.Offers.Add(offer);
        }

        public void Update(Offer offer)
        {
            db.Entry(offer).State = EntityState.Modified;
        }

        public IEnumerable<Offer> Find(Func<Offer, Boolean> predicate)
        {
            return db.Offers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Offer offer = db.Offers.Find(id);
            if (offer != null)
                db.Offers.Remove(offer);
        }
    }
}
