using NLayer.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }
        IRepository<CustomerOffer> CustomerOffers { get; }
        IRepository<Category> Categories { get; }
        IRepository<CompanyOffer> CompanyOffers { get; }
        IRepository<Company> Companies { get; }
        IRepository<Executor> Executors { get; }
        IRepository<Offer> Offers { get; }

        void Save();

    }
}
