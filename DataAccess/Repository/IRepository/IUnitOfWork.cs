namespace CatchMore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISessionRepository Session { get; }
        ICatchRepository Catch { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
