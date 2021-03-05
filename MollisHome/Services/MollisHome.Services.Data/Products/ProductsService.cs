﻿namespace MollisHome.Services.Data.Products
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;
    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Products;

    using System.Linq;
    using System.Collections.Generic;

    public class ProductsService : BaseService<Product, ProductDTO>, IProductsService
    {
        //------------- CONSTRUCTORS --------------
        public ProductsService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------
        public IEnumerable<ProductDTO> GetByCategoryName(string categoryName)
        {
            return this.dbSet.Where(x => x.Category.Name == categoryName).Select(x => this.mapper.Map<Product, ProductDTO>(x)).ToList();
        }
    }
}