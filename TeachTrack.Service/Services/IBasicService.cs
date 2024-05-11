namespace TeachTrack.Service.Services;

public interface IBasicService<T> {
   public Task<IEnumerable<T>> Get();
   public Task<T> GetById(int id);
}