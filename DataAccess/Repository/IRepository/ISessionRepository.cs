using CatchMore.Models;

namespace CatchMore.DataAccess.Repository.IRepository
{
    public interface ISessionRepository : IRepository<Session>
    {
        void Update(Session obj);
    }
}
