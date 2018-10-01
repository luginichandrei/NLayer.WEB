
using NLayer.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DAL.EF
{
    public class CodeContext : DbContext
    {
        public CodeContext() : base("BaseConnection") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOffer> CustomerOffers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<CompanyOffer> CompanyOffers { get; set; }

        static CodeContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }

        public CodeContext(string connectionString)

            : base(connectionString) { }

        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<CodeContext>
        {
            protected override void Seed(CodeContext db)
            {
                db.Customers.Add(new Customer { FirstName = "Andrew", LastName = "Luhinich", PhoneNumber = "09344567231", Id=1 });
                db.CustomerOffers.Add(new CustomerOffer { Order = "I want to eat", Price = 15, CustomerID = 1, TimeRealization = "1" });
                db.Categories.Add(new Category { Name = "Service", Id = 1 });
                db.Categories.Add(new Category { Name = "Work", Id=2 });
                db.Offers.Add(new Offer { Name = "Education", CurrentCategory = 2 });
                db.Offers.Add(new Offer { Name = "Services for Animals", CurrentCategory = 1 });
                db.Companies.Add(new Company { Name = "CompanyOfTom", Adress = "Chernivtsi" });
                db.SaveChanges();
            }
        }
    }
}
