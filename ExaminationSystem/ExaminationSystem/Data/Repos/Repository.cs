using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace ExaminationSystem.Data.Repos
{
    public class Repository<Entity> : IRepository<Entity> where Entity : BaseModel
    {
        private readonly DbSet<Entity> _dbSet;

        private readonly AppDbContext _context ;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }
        public void Add(Entity entity)
        {
            entity.CreatedDate = DateTime.Now;
            _dbSet.Add(entity);
        }

        public void Delete(Entity entity)
        {
            entity.Deleted = true;
            SaveInclude(entity,nameof(BaseModel.Deleted));
        }


        public IQueryable<Entity> GetAll() => _dbSet.Where(e=>!e.Deleted);
        public IQueryable<Entity> GetAllWithIncludes(Func<IQueryable<Entity>, IQueryable<Entity>> includeExpression)
        {
            var set = _dbSet.Where(e => !e.Deleted);
            return includeExpression(set);
        }
        

        public IQueryable<Entity> GetAllWithDeleted() => _dbSet;

        public Entity GetByID(int id)
        {
            return GetAll().FirstOrDefault(e=>e.ID==id);
        }



        public bool IsFound(int id)
        {
            return _dbSet.Any(e=>e.ID==id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SaveInclude(Entity entity, params string[] properties)
        {
            var local = _dbSet.Local.FirstOrDefault(x => x.ID == entity.ID);

            EntityEntry entry = null;

            if (local is null)
            {
                entry = _dbSet.Entry(entity);
            }
            else
            {
                entry = _context.ChangeTracker.Entries<Entity>()
                    .FirstOrDefault(x => x.Entity.ID == entity.ID);
            }

            foreach (var property in entry.Properties)
            {
                if (properties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }
            }

        }
    }
}