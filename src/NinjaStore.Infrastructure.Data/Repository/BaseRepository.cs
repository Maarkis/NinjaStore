using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NinjaStore.Domain.Interfaces.Repositories;
using NinjaStore.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjaStore.Infrastructure.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly DatabaseContext _context;
        public readonly SqlConnection _connection;

        public BaseRepository(DatabaseContext context, IConfiguration _configuration)
        {
            _context = context;
            _connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
        }
        public void Delete(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }  
        public void Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public IList<TEntity> Select()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Select(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
            GC.SuppressFinalize(this);
        }

    }
}
