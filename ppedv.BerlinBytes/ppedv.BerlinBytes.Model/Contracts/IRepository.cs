using ppedv.BerlinBytes.Model.DomainModel;
using Version = ppedv.BerlinBytes.Model.DomainModel.Version;

namespace ppedv.BerlinBytes.Model.Contracts
{
    public interface IUnitOfWork
    {
        IComputerRepository ComputerRepo { get; }
        IRepository<App> AppRepo { get; }
        IRepository<Version> VersionRepo { get; }

        void SaveAll();
    }

    public interface IComputerRepository : IRepository<Computer>
    {
        /// <summary>
        /// EagerLoading Computers and all
        /// </summary>
        IEnumerable<Computer> GetComputersIncludeAppsAndVersions();
    }

    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Query();
        T? GetById(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
