using GreenMailing.DataAccessLayer.Abstract.IGenericRepository;
using GreenMailing.DataTransferObjectLayer.Concrete.Dtos;
using GreenMailing.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMailing.DataAccessLayer.Abstract.IAbstractDal
{
    public interface IUserDal : IGenericRepository<User>
    {
        Task CreateUserAsync(CreateUserDto createUserDto);
    }
}