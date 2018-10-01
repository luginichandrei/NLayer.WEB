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
    public class CustomerRepository : IRepository<Customer>
    {
        private CodeContext db;

        public CustomerRepository(CodeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers;
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
        }

        public IEnumerable<Customer> Find(Func<Customer, Boolean> predicate)
        {
            return db.Customers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
                db.Customers.Remove(customer);
        }
    }
}
