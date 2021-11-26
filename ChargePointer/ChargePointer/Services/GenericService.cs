using System.Collections.Generic;
using ChargePointer.Repositories;

namespace ChargePointer.Services
{
    public class GenericService<T, PK> : IService<T, PK>
        where T : class
    {
        private readonly IRepository<T, PK> _repository;

        public GenericService(IRepository<T, PK> repository)
        {
            _repository = repository;
        }

        public T Get(PK id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Create(T t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(PK id)
        {
            throw new System.NotImplementedException();
        }
    }
}