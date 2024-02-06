using CatchMore.DataAccess.Data;
using CatchMore.DataAccess.Repository.IRepository;

namespace CatchMore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ISessionRepository Session {get; private set; }
        public ICatchRepository Catch {get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Session = new SessionRepository(_db);
            Catch = new CatchRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
