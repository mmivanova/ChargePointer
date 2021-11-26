using System.Collections.Generic;

namespace ChargePointer.Repositories
{
    public interface IRepository<T, PK>
        where T : class
    {
        T Get(PK id);
        IEnumerable<T> GetAll();
        void Create(T t);
        void Update(T t);
        void Delete(PK id);
    }
}