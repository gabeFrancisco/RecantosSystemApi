using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecantosSystem.Api.Interfaces
{
	public interface IBaseService<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetAsync(int id);
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity, int id);
		Task<bool> DeleteAsync(int id);
	}
}