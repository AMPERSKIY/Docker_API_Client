using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByIdWithToken(int userId);
        Task<User> GetByEmailWithToken(string email);
    }
}
