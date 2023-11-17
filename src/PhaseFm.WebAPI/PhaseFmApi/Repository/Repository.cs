using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;

namespace PhaseFmApi.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly DbContext _databaseContext;

		public Repository(PhaseFmContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task<TEntity> Create(TEntity entity)
		{
			if (entity is ICreatable creatable) creatable.DateCreated = DateTime.Now;

			if (entity is IDeletable softDeletable) softDeletable.IsDeleted = false;

			_databaseContext.Add(entity);

			int numRowsAffected = await _databaseContext.SaveChangesAsync();
			if (numRowsAffected == 0) { return null; }
			else
			{
				return entity;
			}


		}

		public async Task<bool> DeleteById(int id)
		{
			var row = await _databaseContext.Set<TEntity>().FindAsync(id);
			if (row == null) { return false; }
			else
			{
				if (row is IDeletable deletable)
				{
					deletable.IsDeleted = true;
					deletable.DateDeleted = DateTime.Now;
				}
				else
				{
					_databaseContext.Set<TEntity>().Remove(row);

				}
				await _databaseContext.SaveChangesAsync();
				return true;
			}

		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			var set = _databaseContext.Set<TEntity>();

			return await set.ToListAsync();
		}

		public async ValueTask<TEntity?> GetById(int id)
		{
			var row = await _databaseContext.Set<TEntity>().FindAsync(id);

			return row;
		}

		public async Task<TEntity> Update(TEntity entity)
		{
			if (entity is IUpdatable updatable) updatable.DateUpdated = DateTime.Now;

			_databaseContext.Set<TEntity>().Update(entity);

			var rowsAffected = await _databaseContext.SaveChangesAsync();
			if (rowsAffected == 0) { return null; }
			else
			{
				return entity;
			}


		}
	}
}
