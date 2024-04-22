using GreenMailing.DataAccessLayer.Abstract.IAbstractDal;
using GreenMailing.DataAccessLayer.Abstract.IGenericRepository;
using GreenMailing.DataAccessLayer.Concrete.Context;
using GreenMailing.DataAccessLayer.Concrete.GenericRepository;
using GreenMailing.DataTransferObjectLayer.Concrete.Dtos;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.DataAccessLayer.Concrete.ConcreteDal.EntityFramework
{
    public class UserDal : EfGenericRepository<User, GreenMailingDbContext>, IUserDal
    {
		private readonly UserManager<User> _userManager;
		public UserDal(IdentityDbContext<User, Role, int> context, UserManager<User> userManager) : base(context)
		{
			_userManager = userManager;
		}

		public async Task CreateUserAsync(CreateUserDto createUserDto)
		{
			User user = new User()
			{
				FirstName = createUserDto.FirstName,
				LastName = createUserDto.LastName,
				UserName = createUserDto.UserName,
				Email = createUserDto.Email
			};
			await _userManager.CreateAsync(user, createUserDto.Password);
		}
	}
}