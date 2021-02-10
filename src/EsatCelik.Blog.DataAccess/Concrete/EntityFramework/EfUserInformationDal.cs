using System;
using System.Collections.Generic;
using System.Text;
using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;
using EsatCelik.Core.DataAccess.EntityFramework;

namespace EsatCelik.Blog.DataAccess.Concrete.EntityFramework
{
    public class EfUserInformationDal : EfRepositoryBase<UserInformation, BlogContext>, IUserInformationDal
    {
        public EfUserInformationDal(BlogContext context) : base(context)
        {
        }
    }
}
