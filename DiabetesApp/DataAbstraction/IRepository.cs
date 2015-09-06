using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiabetesApp.Models;
using DiabetesApp.ViewModels;
using System.Linq.Expressions;

namespace DiabetesApp.DataAbstraction 
{
    public interface IRepository<T>: IDisposable where T: class
    {
        IEnumerable<T> SelectDataByParams(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> order);
        T SelectModelID(object id);
        void Delete(T obj);
        void Add(T obj);
        void Save();
        
    }
}