using CatchMore.DataAccess.Data;
using CatchMore.DataAccess.Repository.IRepository;
using CatchMore.Models;

namespace CatchMore.DataAccess.Repository;

public class CatchRepository : Repository<Catch>, ICatchRepository
{
    private ApplicationDbContext _db;

    public CatchRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Catch obj)
    {
        _db.Update(obj);
    }
}