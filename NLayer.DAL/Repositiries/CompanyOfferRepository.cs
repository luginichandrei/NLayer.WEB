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
    public class CompanyOfferRepository : IRepository<CompanyOffer>
    {
        private CodeContext db;

        public CompanyOfferRepository(CodeContext context)
        {
            this.db = context;
        }

        public IEnumerable<CompanyOffer> GetAll()
        {
            return db.CompanyOffers;
        }

        public CompanyOffer Get(int id)
        {
            return db.CompanyOffers.Find(id);
        }

        public void Create(CompanyOffer companyOffer)
        {
            db.CompanyOffers.Add(companyOffer);
        }

        public void Update(CompanyOffer companyOffer)
        {
            db.Entry(companyOffer).State = EntityState.Modified;
        }

        public IEnumerable<CompanyOffer> Find(Func<CompanyOffer, Boolean> predicate)
        {
            return db.CompanyOffers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            CompanyOffer companyOffers = db.CompanyOffers.Find(id);
            if (companyOffers != null)
                db.CompanyOffers.Remove(companyOffers);
        }
    }
}
