﻿namespace MollisHome.Services.Data.Base
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.DTOs.Base;

    using Microsoft.EntityFrameworkCore;

    using System.Linq;
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

        public IEnumerable<TDTO> GetAll()
        {
            return this.dbSet.Select(x => this.mapper.Map<TModel, TDTO>(x)).ToList();
        }

        public TDTO GetById(int id)
        {
            return this.mapper.Map<TModel, TDTO>(this.dbSet.FirstOrDefault(x => x.Id == id));
        }

        public TDTO GetByName(string name)
        {
            return this.mapper.Map<TModel, TDTO>(this.dbSet.FirstOrDefault(x => x.Name == name));
        }

        public void Create(TModel item)
        {
            this.dbSet.Add(item);
            this.dbContext.SaveChanges();
        }

        public void Update(TModel item)
        {
            this.dbContext.Entry(item).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public void Save(TModel item)
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
            var entity = this.dbSet.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;

            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}