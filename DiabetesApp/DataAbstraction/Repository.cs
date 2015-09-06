using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiabetesApp.Models;
using DiabetesApp.ViewModels;
using PagedList;
using System.Data.Entity;
using System.Linq.Expressions;
using AutoMapper;

namespace DiabetesApp.DataAbstraction
{
    public class Repository<T> : IRepository<T> where T: class
    {

        private InputModelDBContext db;
        private DbSet<T> table;
        private string _user = HttpContext.Current.User.Identity.Name.ToString();
        
        public Repository()
        {
            this.db = new InputModelDBContext();
            table = db.Set<T>();
        }

        public Repository(InputModelDBContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public T SelectModelID(object id)
        {

            return table.Find(id);
           
        }

        public void Delete(T obj)
        {
            table.Remove(obj);
        }

        public void Add(T obj)
        {
            db.Entry(obj).State = EntityState.Added;
        }

        public IEnumerable<T> SelectDataByParams(Expression<Func<T, bool>> where,Func<IQueryable<T>, IOrderedQueryable<T>> order)
        {
            IQueryable<T> model = table;

            if (where != null)
            {
                model = model.Where(where);
            }
            if (order != null)
            {
                model = order(model);
            }
           
            return model;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
     }
}
    
