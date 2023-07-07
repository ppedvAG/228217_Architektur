using Microsoft.EntityFrameworkCore;
using ppedv.BerlinBytes.Model.Contracts;
using ppedv.BerlinBytes.Model.DomainModel;

namespace ppedv.BerlinBytes.Data.Db
{
    public class EfUnitOfWork : IUnitOfWork
    {
        readonly EfContext _context;

        public EfUnitOfWork(string conString)
        {
            _context = new EfContext(conString);
        }

        public IComputerRepository ComputerRepo => new EfComputerRepository(_context);

        public IRepository<App> AppRepo => new EfRepository<App>(_context);

        public IRepository<Model.DomainModel.Version> VersionRepo => new EfRepository<Model.DomainModel.Version>(_context);

        public void SaveAll()
        {
            _context.SaveChanges();
        }
    }
    public class EfComputerRepository : EfRepository<Computer>, IComputerRepository
    {
        public EfComputerRepository(EfContext context) : base(context)
        { }

        public IEnumerable<Computer> GetComputersIncludeAppsAndVersions()
        {
            return _context.Set<Computer>().Include(x => x.Apps).ThenInclude(x => x.Versions);
        }
    }

    public class EfRepository<T> : IRepository<T> where T : Entity
    {

        protected EfContext _context;

        public EfRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public T? GetById(int id)
        {
            return _context.Find<T>(id);
        }


        public void Update(T entity)
        {
            _context.Update(entity);
        }


    }
}
