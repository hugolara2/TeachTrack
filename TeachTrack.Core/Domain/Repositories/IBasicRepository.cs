namespace TeachTrack.Core.Domain.Repositories;

public interface IBasicRepository<TEntity> {
   Task<IEnumerable<TEntity>> Get();
   Task<TEntity> GetById(int id);
}