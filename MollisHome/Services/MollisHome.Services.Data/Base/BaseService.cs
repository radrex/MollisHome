namespace MollisHome.Services.Data.Base
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.DTOs.Base;

    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public abstract class BaseService<TModel, TDTO> : IBaseService<TModel, TDTO> where TModel: BaseModel where TDTO: BaseDTO
    {
        //---------------- FIELDS -----------------
        protected readonly IMapper mapper;
        protected readonly ApplicationDbContext dbContext;
        protected readonly DbSet<TModel> dbSet;

        //------------- CONSTRUCTORS --------------
        public BaseService(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TModel>();
        }

        public bool HasEntities()
        {
            return this.dbSet.Any();
        }

        public IEnumerable<TDTO> GetAll()
        {
            return this.dbSet.Select(x => this.mapper.Map<TModel, TDTO>(x)).ToList();
        }

        public TDTO GetById(int id)
        {
            return this.mapper.Map<TModel, TDTO>(this.dbSet.FirstOrDefault(x => x.Id == id));
        }

        public Task CreateAsync(TDTO item)
        {
            TModel model = this.mapper.Map<TDTO, TModel>(item);
            this.dbSet.Add(model);
            return this.dbContext.SaveChangesAsync(); // TODO: Throws exception if UNIQUE and CHECK CONSTRAINTS are not passing. Handle the exceptions.
        }

        public void Update(TModel item)
        {
            this.dbContext.Entry(item).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        //public void Save(TModel item)
        //{
        //    if (item.Id != 0)
        //    {
        //        this.Update(item);
        //    } 
        //    else
        //    {
        //        this.CreateAsync(item);
        //    }
        //}

        public void Delete(int id)
        {
            var entity = this.dbSet.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;

            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
