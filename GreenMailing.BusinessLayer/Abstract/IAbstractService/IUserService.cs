using GreenMailing.BusinessLayer.Abstract.IGenericService;
using GreenMailing.DataTransferObjectLayer.Concrete.Dtos;
using GreenMailing.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.BusinessLayer.Abstract.IAbstractService
{
    public interface IUserService : IGenericService<User>
    {
		Task CreateUserAsync(CreateUserDto createUserDto);
	}
}