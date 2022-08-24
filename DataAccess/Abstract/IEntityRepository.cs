using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T: class, IEntity,new()
    {
        //filtrelemek için.  Expression sorguyu ayrı ayrı yazmadan tek kodda istenilen filtreleri girmemizi sağlıyor. null olması filtre vermeye de biliriz demek
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //Tek veriye gitmek için
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
