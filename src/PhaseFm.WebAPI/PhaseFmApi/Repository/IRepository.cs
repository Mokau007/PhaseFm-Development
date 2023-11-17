namespace PhaseFmApi.Repository
{
  public interface IRepository<TEntity> where TEntity : class
  {
		Task<IEnumerable<TEntity>> GetAll();

		ValueTask<TEntity?> GetById(int id);

		Task<TEntity> Create(TEntity entity);

		Task<TEntity> Update(TEntity entity);

		Task<bool> DeleteById(int id);
	}
}
