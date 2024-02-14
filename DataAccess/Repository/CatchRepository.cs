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
        var objFromDb = _db.Catches.FirstOrDefault(i => i.Id == obj.Id);
        if (objFromDb != null) 
        {
            objFromDb.Date = obj.Date;
            objFromDb.Description = obj.Description;
            objFromDb.Session = obj.Session;
            objFromDb.SessionId = obj.SessionId;
            objFromDb.Weight = obj.Weight;
            objFromDb.Length = obj.Length;
            objFromDb.Species = obj.Species;
            if (obj.Image != null)
            {
                objFromDb.Image = obj.Image;
            }

        }
    }
}