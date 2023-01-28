

namespace keeper.Interfaces;

public interface IRepository<T, Tid>
{
  List<T> Get();
  T GetOne(Tid id);

  T Create(T Body);

  bool Update(T update);
  bool Delete(Tid id);

}
