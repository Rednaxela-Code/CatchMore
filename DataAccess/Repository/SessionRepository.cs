using CatchMore.DataAccess.Data;
using CatchMore.DataAccess.Repository.IRepository;
using CatchMore.Models;

namespace CatchMore.DataAccess.Repository
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        private ApplicationDbContext _db;

        public SessionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Session obj)
        {
            _db.Update(obj);
        }
    }
}
