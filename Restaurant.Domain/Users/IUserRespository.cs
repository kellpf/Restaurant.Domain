using Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public interface IUserRespository
    {
        Task<List<User>> FindAll();
        Task<User> FindById(int idUser);
        Task Create(User user);
        Task Update(User user);
        Task Delete(int idUser);
    }
}
