namespace MovieChallenge.Api.Services
{
    public class BaseCollection<TModel> : IBaseCollection<TModel> where TModel : new()
    {
        public BaseCollection()
        {

        }

        public Task Create(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<long> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<long> Update(string id, TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
