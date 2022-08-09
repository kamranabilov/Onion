using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces.Repositories;
using Onion.Domain.Entities.Base;
using Onion.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ProniaDbContext _context;

        public GenericRepository(ProniaDbContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAllAsync()
        {
            List<T> values = await _context.Set<T>().ToListAsync();
            return values;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            T values = await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
            return values;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAysnc(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }      
    }
}
