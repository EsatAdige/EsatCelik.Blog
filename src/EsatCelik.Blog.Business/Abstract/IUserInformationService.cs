using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Abstract
{
    public interface IUserInformationService
    {
        Task<UserInformation> GetByIdAsync(int id);

        Task<ICollection<UserInformation>> GetListAsync();

        Task<UserInformation> UpdateAsync(UserInformation userInformation);

        Task<UserInformation> AddAsync(UserInformation userInformation);

        Task DeleteAsync(int id);
    }
}
