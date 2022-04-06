namespace FootballManager.Data.Common
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        IQueryable<T> All<T>() where T : class;

        int SaveChanges();

        public void Delete<TEntity>(TEntity entity) where TEntity : class;
    }
}
