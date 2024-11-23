using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExaminationSystem.Data.Repos
{
    public interface IRepository<Entity>
    {
        void Add(Entity entity);
        void SaveInclude(Entity entity, params string[] properties);
        void Delete(Entity entity);
        IQueryable<Entity> GetAll();
        IQueryable<Entity> GetAllWithDeleted();
        public IQueryable<Entity> GetAllWithIncludes(
    Func<IQueryable<Entity>, IQueryable<Entity>> includeExpression);
        Entity GetByID(int id);
        bool IsFound(int id);
        void SaveChanges();
    }
}
