﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsatCelik.Blog.Business.Abstract;
using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.Entities.Concrete;

namespace EsatCelik.Blog.Business.Concrete
{
    public class UserInformationManager : IUserInformationService
    {
        private readonly IUserInformationDal _userInformationDal;

        public UserInformationManager(IUserInformationDal userInformationDal)
        {
            _userInformationDal = userInformationDal;
        }

        public async Task<UserInformation> GetById(int id)
        {
            return await _userInformationDal.GetAsync(x => x.Id == id);
        }

        public async Task<ICollection<UserInformation>> GetList()
        {
            return await _userInformationDal.GetListAsync(null, x => x.OrderByDescending(o => o.InsertDate));
        }

        public async Task<UserInformation> Update(UserInformation userInformation)
        {
            var newUserInformation = await _userInformationDal.UpdateAsync(userInformation);
            await _userInformationDal.CommitAsync();

            return newUserInformation;
        }

        public async Task<UserInformation> Add(UserInformation userInformation)
        {
            var newUserInformation = await _userInformationDal.AddAsync(userInformation);
            await _userInformationDal.CommitAsync();

            return newUserInformation;
        }

        public async Task Delete(int id)
        {
            var userInformation = await _userInformationDal.GetAsync(x => x.Id == id);

            await _userInformationDal.DeleteAsync(userInformation);
            await _userInformationDal.CommitAsync();
        }
    }
}
