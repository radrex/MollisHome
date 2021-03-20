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

        public async Task<string> CreateAsync(TDTO item)
        {
            // Make some kind of validation before the try catch for the db I guess...

            TModel model = this.mapper.Map<TDTO, TModel>(item);
            
            try // maybe use another catch for different exception, check exception order execution for that
            {
                await this.dbSet.AddAsync(model);
                await this.dbContext.SaveChangesAsync();
                return $"Entity with ID: {model.Id} created.";
            }
            catch (DbUpdateException e)
            {
                this.dbContext.Entry<TModel>(model).State = EntityState.Detached;
                return ExceptionPrettifier.PrettifyExceptionMessage(e.InnerException.Message);
            }
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

        public async Task<string> RemoveAsync(int id)
        {
            // have to remove mapping table entities as well

            var entity = this.dbSet.Find(id);
            if (entity is null)
            {
                return $"Entity with ID: {id} doesn't exist.";
            }

            this.dbSet.Remove(entity);
            await this.dbContext.SaveChangesAsync();
            return $"Entity with ID: {id} removed successfully. All entities associated with it are also deleted.";
        }
    }
}
