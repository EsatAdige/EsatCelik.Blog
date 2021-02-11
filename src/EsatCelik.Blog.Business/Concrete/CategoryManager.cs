using EsatCelik.Blog.Business.Abstract;
using EsatCelik.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EsatCelik.Blog.DataAccess.Abstract;

namespace EsatCelik.Blog.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<Category> Add(Category category)
        {
            var newCategory = await _categoryDal.AddAsync(category);
            await _categoryDal.CommitAsync();

            return newCategory;
        }

        public async Task Delete(int id)
        {
            var category = await _categoryDal.GetAsync(x => x.Id == id);

            await _categoryDal.DeleteAsync(category);
            await _categoryDal.CommitAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryDal.GetAsync(x => x.Id == id);
        }

        public async Task<ICollection<Category>> GetList(string categoryName = "")
        {
            List<Expression<Func<Category, bool>>> filters = new List<Expression<Func<Category, bool>>>();

            if (!string.IsNullOrEmpty(categoryName))
                filters.Add(category => category.CategoryName.Contains(categoryName));


            return await _categoryDal.GetListAsync(filters, x => x.OrderByDescending(x => x.InsertDate));
        }

        public async Task<Category> Update(Category category)
        {
            var newCategory = await _categoryDal.UpdateAsync(category);
            await _categoryDal.CommitAsync();

            return newCategory;
        }
    }
}
