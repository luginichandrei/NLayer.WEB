using NLayer.DAL.EF;
using NLayer.DAL.Entites;
using NLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DAL.Repositiries
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CodeContext db;

        private CustomerRepository customerRepository;
        private CustomerOfferRepository customerOfferRepository;
        private CompanyRepository companyRepository;
        private CategoryRepository categoryRepository;
        private CompanyOfferRepository companyOfferRepository;
        private OfferRepository offerRepository;
        private ExecutorRepository executorRepository;
                     
        public EFUnitOfWork(string connectionString)
        {
            db = new CodeContext(connectionString);
        }

        public IRepository<Customer> Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }

        public IRepository<CustomerOffer> CustomerOffers
        {
            get
            {
                if (customerOfferRepository == null)
                    customerOfferRepository = new CustomerOfferRepository(db);
                return customerOfferRepository;
            }
        }

        public IRepository<Company> Companies
        {
            get
            {
                if (companyRepository == null)
                    companyRepository = new CompanyRepository(db);
                return companyRepository;
            }
        }

        public IRepository<CompanyOffer> CompanyOffers
        {
            get
            {
                if (companyOfferRepository == null)
                    companyOfferRepository = new CompanyOfferRepository(db);
                return companyOfferRepository;
            }
        }

        public IRepository<Offer> Offers
        {
            get
            {
                if (offerRepository == null)
                    offerRepository = new OfferRepository(db);
                return offerRepository;
            }
        }

        public IRepository<Executor> Executors
        {
            get
            {
                if (executorRepository == null)
                    executorRepository = new ExecutorRepository(db);
                return executorRepository;
            }
        }


        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }
                                   
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
