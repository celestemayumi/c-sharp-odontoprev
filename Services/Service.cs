using c_sharp_odontoprev.Repositories;

namespace c_sharp_odontoprev.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(T entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
