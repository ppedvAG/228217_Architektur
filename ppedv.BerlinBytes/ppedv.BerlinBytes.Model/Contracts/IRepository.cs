using ppedv.BerlinBytes.Model.DomainModel;

namespace ppedv.BerlinBytes.Model.Contracts
{
    public interface IRepository
    {
        /// <summary>
        /// EagerLoading Computers and all
        /// </summary>
        IEnumerable<Computer> GetComputersIncludeAppsAndVersions();

        IQueryable<T> Query<T>() where T : Entity;
        T? GetById<T>(int id) where T : Entity;

        void Add<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;

        void SaveAll();
    }
}
