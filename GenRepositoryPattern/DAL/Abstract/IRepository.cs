using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenRepositoryPattern.DAL.Abstract
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindBy(object id);
        void Add(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}