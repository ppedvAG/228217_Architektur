﻿using Microsoft.EntityFrameworkCore;
using ppedv.BerlinBytes.Model.Contracts;
using ppedv.BerlinBytes.Model.DomainModel;

namespace ppedv.BerlinBytes.Data.Db
{
    public class EfRepository : IRepository
    {
        readonly EfContext _context;

        public EfRepository(string conString)
        {
            _context = new EfContext(conString);
        }

        public void Add<T>(T entity) where T : Entity
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return _context.Find<T>(id);
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Update(entity);
        }

        public IEnumerable<Computer> GetComputersIncludeAppsAndVersions()
        {
            return _context.Set<Computer>().Include(x => x.Apps).ThenInclude(x => x.Versions);
        }
    }
}
