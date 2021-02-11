using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface IUserInformationService
    {
        Task<UserInformation> GetById(int id);

        Task<ICollection<UserInformation>> GetList();

        Task<UserInformation> Update(UserInformation userInformation);

        Task<UserInformation> Add(UserInformation userInformation);

        Task Delete(int id);
    }
}
