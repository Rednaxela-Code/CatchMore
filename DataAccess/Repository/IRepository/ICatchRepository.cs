using CatchMore.Models;

namespace CatchMore.DataAccess.Repository.IRepository;

public interface ICatchRepository : IRepository<Catch>
{
    public void Update(Catch obj);
}