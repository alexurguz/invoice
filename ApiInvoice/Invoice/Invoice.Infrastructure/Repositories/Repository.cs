using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Common.Utilities;
using Invoice.Core.Entities;
using Invoice.Core.Interfaces.Repository;
using Invoice.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly InvoiceDBContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(InvoiceDBContext context) {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {   
            T entity = await GetById(id);
            entity.Deleted = Constants.ROW_DELETED;
            _entities.Update(entity);
        }
    }
}