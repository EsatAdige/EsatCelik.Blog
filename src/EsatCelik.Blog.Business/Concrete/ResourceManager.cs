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
    public class ResourceManager: IResourceService
    {
        private readonly IResourceDal _resourceDal;

        public ResourceManager(IResourceDal resourceDal)
        {
            _resourceDal = resourceDal;
        }

        public async Task<Resource> GetById(int id)
        {
            return await _resourceDal.GetAsync(x => x.Id == id);
        }

        public async Task<ICollection<Resource>> GetList(string name = "")
        {
            List<Expression<Func<Resource, bool>>> filters = new List<Expression<Func<Resource, bool>>>();

            if (!string.IsNullOrEmpty(name))
                filters.Add(resurce => resurce.Name.Contains(name));


            return await _resourceDal.GetListAsync(filters, x => x.OrderByDescending(x => x.InsertDate));
        }

        public async Task<Resource> Update(Resource comment)
        {
            var newComment = await _resourceDal.UpdateAsync(comment);
            await _resourceDal.CommitAsync();

            return newComment;
        }

        public async Task<Resource> Add(Resource comment)
        {
            var newComment = await _resourceDal.AddAsync(comment);
            await _resourceDal.CommitAsync();

            return newComment;
        }

        public async Task Delete(int id)
        {
            var resource = await _resourceDal.GetAsync(x => x.Id == id);

            await _resourceDal.DeleteAsync(resource);
            await _resourceDal.CommitAsync();
        }
    }
}
