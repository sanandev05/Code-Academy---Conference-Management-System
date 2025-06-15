using System.Linq.Expressions;
using Code_Academy___Conference_Management_System.Data;
using Code_Academy___Conference_Management_System.Entities;
using Code_Academy___Conference_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code_Academy___Conference_Management_System.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly ConferenceDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ConferenceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.Where(e => !e.IsDeleted);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.Where(e => !e.IsDeleted);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e => e.ID == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
