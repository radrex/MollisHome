namespace MollisHome.Services.Data.Base
{
    using MollisHome.Data;
    using MollisHome.Data.Models;

    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Collections.Generic;

    public abstract class BaseService<T> : IBaseService<T> where T: BaseModel
    {
        //---------------- FIELDS -----------------
        protected readonly ApplicationDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        //------------- CONSTRUCTORS --------------
        public BaseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public T GetById(int id)
        {
            return this.dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(T item)
        {
            this.dbSet.Add(item);
            this.dbContext.SaveChanges();
        }

        public void Update(T item)
        {
            this.dbContext.Entry(item).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public void Save(T item)
        {
            if (item.Id != 0)
            {
                this.Update(item);
            } 
            else
            {
                this.Create(item);
            }
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);
            if (entity == null) return;

            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
