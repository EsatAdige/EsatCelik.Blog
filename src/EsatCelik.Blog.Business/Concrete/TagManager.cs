using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EsatCelik.Blog.Business.Abstract;
using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Concrete
{
    public class TagManager : ITagService
    {
        private readonly ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public async Task<Tag> GetById(int id)
        {
            return await _tagDal.GetAsync(x => x.Id == id);
        }

        public async Task<ICollection<Tag>> GetList(string name = "")
        {
            List<Expression<Func<Tag, bool>>> filters = new List<Expression<Func<Tag, bool>>>();

            if (!string.IsNullOrEmpty(name))
                filters.Add(tag => tag.TagName.Contains(name));


            return await _tagDal.GetListAsync(filters, x => x.OrderByDescending(x => x.InsertDate));
        }

        public async Task<Tag> Update(Tag tag)
        {
            var newTag = await _tagDal.UpdateAsync(tag);
            await _tagDal.CommitAsync();

            return newTag;
        }

        public async Task<Tag> Add(Tag tag)
        {
            var newTag = await _tagDal.AddAsync(tag);
            await _tagDal.CommitAsync();

            return newTag;
        }

        public async Task Delete(int id)
        {
            var tag = await _tagDal.GetAsync(x => x.Id == id);

            await _tagDal.DeleteAsync(tag);
            await _tagDal.CommitAsync();
        }
    }
}
