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
    public class ExecutorRepository : IRepository<Executor>
    {
        private CodeContext db;

        public ExecutorRepository(CodeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Executor> GetAll()
        {
            return db.Executors;
        }

        public Executor Get(int id)
        {
            return db.Executors.Find(id);
        }

        public void Create(Executor executor)
        {
            db.Executors.Add(executor);
        }

        public void Update(Executor executor)
        {
            db.Entry(executor).State = EntityState.Modified;
        }

        public IEnumerable<Executor> Find(Func<Executor, Boolean> predicate)
        {
            return db.Executors.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Executor executor = db.Executors.Find(id);
            if (executor != null)
                db.Executors.Remove(executor);
        }
    }
}
