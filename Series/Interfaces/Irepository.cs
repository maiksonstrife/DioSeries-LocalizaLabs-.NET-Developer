using System.Collections.Generic;

namespace Series.Interfaces
{
    public interface Irepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}