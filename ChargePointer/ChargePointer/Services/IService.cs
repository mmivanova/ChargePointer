using System.Collections.Generic;

namespace ChargePointer.Services
{
    public interface IService<T, PK>
        where T : class
    {
        T Get(PK id);
        IEnumerable<T> GetAll();
        void Create(T t);
        void Update(T chargePoint);
        void Delete(PK id);
    }
}