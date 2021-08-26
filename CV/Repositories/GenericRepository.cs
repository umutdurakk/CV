using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CV.Models.Entity;
namespace CV.Repositories
{
    public class GenericRepository<T> where T:class,new()
    {
        DbCvEntities db = new DbCvEntities(); 
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T data)
        {
            db.Set<T>().Add(data);
            db.SaveChanges();
        }
        public void TDelete(T data)
        {
            db.Set<T>().Remove(data);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T data)
        {
            db.SaveChanges();
        }
        public  T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}