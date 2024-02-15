using CatchMore.DataAccess.Data;
using CatchMore.DataAccess.Repository.IRepository;
using CatchMore.Models;

namespace CatchMore.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
