using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.DataAccessLayer.Abstract.IAbstractDal;
using GreenMailing.DataTransferObjectLayer.Concrete.Dtos;
using GreenMailing.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.BusinessLayer.Concrete.ConcreteManager
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User entity)
        {
            _userDal.Add(entity);
        }

		public async Task CreateUserAsync(CreateUserDto createUserDto)
		{
			await _userDal.CreateUserAsync(createUserDto);
		}

		public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            var values = _userDal.Get(filter);
            return values;
        }

        public List<User> GetAll(Expression<Func<User, bool>>? filter = null)
        {
            var values = _userDal.GetAll(filter);
            return values;
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}