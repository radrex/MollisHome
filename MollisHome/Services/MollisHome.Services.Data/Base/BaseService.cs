namespace MollisHome.Services.Data.Base
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.DTOs.Base;

    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public abstract class BaseService<TModel, TDTO> : IBaseService<TModel, TDTO> where TModel: BaseModel where TDTO: BaseDTO
    {
        //---------------- FIELDS -----------------
        protected readonly IMapper mapper;
        protected readonly ApplicationDbContext dbContext;
        protected readonly DbSet<TModel> dbSet;
        private readonly Dictionary<string, Func<int, Task<string>>> delegates;

        //------------- CONSTRUCTORS --------------
        public BaseService(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TModel>();

            this.delegates = new Dictionary<string, Func<int, Task<string>>>();
            delegates["Color"] = new Func<int, Task<string>>(DeleteColorAndAssociates);
            delegates["Size"] = new Func<int, Task<string>>(DeleteSizeAndAssociates);
            delegates["Gender"] = new Func<int, Task<string>>(DeleteGenderAndAssociates);
            delegates["Material"] = new Func<int, Task<string>>(DeleteMaterialAndAssociates);
            delegates["Product"] = new Func<int, Task<string>>(DeleteProductAndAssociates);
            delegates["Category"] = new Func<int, Task<string>>(DeleteCategoryAndAssociates);
        }

        //--------------- PUBLIC METHODS -----------------
        public bool HasEntities()
        {
            return this.dbSet.Any();
        }

        public bool Exists(int id)
        {
            return this.dbSet.Any(x => x.Id == id);
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
            //TODO: Make some kind of validation before the try catch for the db I guess...

            TModel model = this.mapper.Map<TDTO, TModel>(item);
            
            try // maybe use another catch for different exception, check exception order execution for that
            {
                await this.dbSet.AddAsync(model);
                await this.dbContext.SaveChangesAsync();
                return $"Entity with ID: {model.Id} created. ✔️";
                // TODO: Exception is thrown on SaveChangesAsync() and all is good, but it makes the next creation overlap an index
                // TODO: When creating invalid items it returns message as expected, but after that when creating a valid item, the ID was incremented by the invalid statement.
            }
            catch (DbUpdateException e) 
            {
                this.dbContext.Entry<TModel>(model).State = EntityState.Detached;
                return ExceptionPrettifier.PrettifyExceptionMessage(e.InnerException.Message);
            }
        }

        public async Task<string> EditAsync(TDTO item)
        {
            if (!this.Exists(item.Id))
            {
                return "No such item in the database.";
            }

            //TODO: Make some kind of validation before the try catch for the db I guess...

            TModel model = this.mapper.Map<TDTO, TModel>(item);
            try // maybe use another catch for different exception, check exception order execution for that
            {
                this.dbSet.Update(model);
                await this.dbContext.SaveChangesAsync();
                return $"Entity with ID: {item.Id} updated.";
            }
            catch (DbUpdateException e)
            {
                this.dbContext.Entry<TModel>(model).State = EntityState.Detached;
                return ExceptionPrettifier.PrettifyExceptionMessage(e.InnerException.Message);
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            return await this.delegates[typeof(TModel).Name].Invoke(id);
        }

        //--------------- PRIVATE METHODS -----------------
        private async Task<string> DeleteColorAndAssociates(int colorId)
        {
            var color = await this.dbContext.Colors.FindAsync(colorId);
            if (color is null)
            {
                return $"Color with {colorId} doesn't exist.";
            }

            var stock = color.Products.Where(x => x.Color.Id == color.Id).ToList();
            string[] products = stock.Select(x => x.Product.Name).ToArray();

            this.dbContext.ProductStock.RemoveRange(stock);
            this.dbContext.Remove(color);

            await this.dbContext.SaveChangesAsync();

            // TODO: use tuples as in product delete
            return $"> Color: {color.Name} deleted.{Environment.NewLine}" +
                   $"{(products.Count() != 0 ? $"  > Products deleted from Stock: {String.Join(", ", products)}" : "")}";
        }

        private async Task<string> DeleteSizeAndAssociates(int sizeId)
        {
            var size = await this.dbContext.Sizes.FindAsync(sizeId);
            if (size is null)
            {
                return $"Size with {sizeId} doesn't exist.";
            }

            var stock = size.Products.Where(x => x.Size.Id == sizeId).ToList();
            string[] products = stock.Select(x => x.Product.Name).ToArray();

            this.dbContext.ProductStock.RemoveRange(stock);
            this.dbContext.Remove(size);

            await this.dbContext.SaveChangesAsync();

            // TODO: use tuples as in product delete
            return $"> Size: {size.Name} deleted.{Environment.NewLine}" +
                   $"{(products.Count() != 0 ? $"Products deleted from Stock: {String.Join(", ", products)}" : "")}";
        }

        private async Task<string> DeleteGenderAndAssociates(int genderId)
        {
            var gender = await this.dbContext.Genders.FindAsync(genderId);
            if (gender is null)
            {
                return $"Gender with {genderId} doesn't exist.";
            }

            var stock = gender.Products.Where(x => x.Gender.Id == genderId).ToList();
            string[] products = stock.Select(x => x.Product.Name).ToArray();

            this.dbContext.ProductStock.RemoveRange(stock);
            this.dbContext.Remove(gender);

            await this.dbContext.SaveChangesAsync();

            // TODO: use tuples as in product delete
            return $"> Gender: {gender.Name} deleted.{Environment.NewLine}" +
                   $"{(products.Count() != 0 ? $"  > Products deleted from Stock: {String.Join(", ", products)}" : "")}";
        }

        private async Task<string> DeleteMaterialAndAssociates(int materialId)
        {
            var material = await this.dbContext.Materials.FindAsync(materialId);
            if (material is null)
            {
                return $"Material with {materialId} doesn't exist.";
            }

            var productMaterials = material.Products.Where(x => x.Material.Id == materialId).ToList();
            string[] products = productMaterials.Select(x => x.Product.Name).ToArray();

            this.dbContext.ProductMaterials.RemoveRange(productMaterials);
            this.dbContext.Remove(material);

            await this.dbContext.SaveChangesAsync();

            // TODO: use tuples as in product delete
            return $"> Material: {material.Name} deleted.{Environment.NewLine}" +
                   $"{(products.Count() != 0 ? $"  > Products deleted from ProductMaterials: {String.Join(", ", products)}" : "")} ";
        }

        private async Task<string> DeleteProductAndAssociates(int productId)
        {
            var product = await this.dbContext.Products.FindAsync(productId);
            if (product is null)
            {
                return $"Product with {productId} doesn't exist.";
            }

            var productMaterials = product.Materials.Where(x => x.Product.Id == productId).ToList();
            string[] materials = productMaterials.Select(x => x.Material.Name).ToArray();
            this.dbContext.ProductMaterials.RemoveRange(productMaterials);

            var productStock = product.Stock.Where(x => x.Product.Id == productId).ToList();
            var genderSizeColor = productStock.Select(x => new Tuple<string, string, string>(x.Gender.Name, x.Size.Name, x.Color.Name)).ToList();
            this.dbContext.ProductStock.RemoveRange(productStock);

            var productCarts = product.Carts.Where(x => x.Product.Id == productId).ToList();
            var userCarts = productCarts.Select(x => x.Cart.User.UserName).ToList();
            this.dbContext.RemoveRange(productCarts);

            this.dbContext.Remove(product);
            await this.dbContext.SaveChangesAsync();

            return $"> Product: {product.Name} deleted.{Environment.NewLine}" +
                   $"{(materials.Count() != 0 ? $"  > Materials: {String.Join(", ", materials)} deleted from ProductMaterials.{Environment.NewLine}" : "")}" +
                   $"{(genderSizeColor.Count() != 0 ? $"  > ProductStock deletions: {Environment.NewLine}{String.Join(Environment.NewLine, genderSizeColor.Select(x => $"    > Gender: {x.Item1}, Size: {x.Item2}, Color: {x.Item3}"))}{Environment.NewLine}" : "")}" +
                   $"{(userCarts.Count() != 0 ? $"  > Carts for {String.Join(", ", userCarts)} users deleted from ProductCarts." : "")}";
        }

        private async Task<string> DeleteCategoryAndAssociates(int categoryId)
        {
            Category category = await this.dbContext.Categories.FindAsync(categoryId);
            if (category is null)
            {
                return $"Category with {categoryId} doesn't exist.";
            }

            string message = this.DeleteCategoriesRecursively(category, 0);
            await this.dbContext.SaveChangesAsync();
            return message;
        }

        private string DeleteCategoriesRecursively(Category category, int indentationSpaces)
        {
            List<string> messages = new List<string>();
            if (category.IsLastNode)
            {
                List<string> orphanProducts = new List<string>();
                foreach (Product product in category.Products)
                {
                    orphanProducts.Add(product.Name);
                    product.CategoryId = null;
                }

                this.dbContext.Remove(category);

                messages.Add($"{new string(' ', indentationSpaces)}> Category: {category.Name} deleted.{Environment.NewLine}" +
                             $"{(orphanProducts.Count() != 0 ? $"{new string(' ', indentationSpaces + 2)}> Products deasociated: {String.Join(", ", orphanProducts)}{Environment.NewLine}" : "")}");
            }
            else
            {
                foreach (Category childCategory in category.Categories)
                {
                    messages.Add(this.DeleteCategoriesRecursively(childCategory, indentationSpaces + 2));
                }

                category.IsLastNode = true;
                messages.Add(this.DeleteCategoriesRecursively(category, indentationSpaces));
            }

            messages.Reverse();
            return String.Join("", messages);
        }
    }
}
