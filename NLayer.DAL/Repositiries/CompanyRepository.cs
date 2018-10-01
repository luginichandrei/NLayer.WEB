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
    public class CompanyRepository : IRepository<Company>
    {
        private CodeContext db;

        public CompanyRepository(CodeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Company> GetAll()
        {
            return db.Companies;
        }

        public Company Get(int id)
        {
            return db.Companies.Find(id);
        }

        public void Create(Company company)
        {
            db.Companies.Add(company);
        }

        public void Update(Company company)
        {
            db.Entry(company).State = EntityState.Modified;
        }

        public IEnumerable<Company> Find(Func<Company, Boolean> predicate)
        {
            return db.Companies.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Company company = db.Companies.Find(id);
            if (company != null)
                db.Companies.Remove(company);
        }
    }
}
