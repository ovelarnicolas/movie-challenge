namespace MovieChallenge.Api.Services
{
    public interface IBaseCollection<TModel>
    {
        Task<IEnumerable<TModel>> GetAll();
        Task<IEnumerable<TModel>> GetById(string id);
        Task Create(TModel model);
        Task<long> Update(string id, TModel model);
        Task<long> Delete(string id);

    }
}
