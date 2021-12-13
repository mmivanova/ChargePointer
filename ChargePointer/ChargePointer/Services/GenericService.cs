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

        public virtual T Get(PK id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(T t)
        {
            _repository.Create(t);
        }

        public virtual void Update(T t)
        {
            _repository.Update(t);
        }

        public void Delete(PK id)
        {
            _repository.Delete(id);
        }
    }
}