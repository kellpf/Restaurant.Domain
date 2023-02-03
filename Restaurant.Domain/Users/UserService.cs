using Domain.Users.Models;
using Domain.Users.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class UserService : IUserService
    {
        public IUserRespository _userRespository;

        public UserService(IUserRespository userRepository)
        {
            _userRespository = userRepository;
        }

        public Task Create(User user)
        {
            UserValidator validator = new UserValidator();
            var validation = validator.Validate(user);
            if (!validation.IsValid)
                return Task.FromResult(validation.ToString());

            _userRespository.Create(user);
            return Task.FromResult(user);
        }

        public Task Delete(int idUser)
        {
            if (idUser <= 0)
                return Task.FromResult("O id deve ser maior que zero");

            _userRespository.Delete(idUser);
            return Task.CompletedTask;
        }

        public async Task<List<User>> FindAll()
        {
            var users = await _userRespository.FindAll();

            return users;
        }

        public async Task<User> FindById(int idUser)
        {
            var user = await _userRespository.FindById(idUser);
                return user;
        }

        public Task Update(User user)
        {
            UserValidator validator = new UserValidator();
            var validation = validator.Validate(user);
            if (!validation.IsValid)
                return Task.FromResult(validation.ToString());

            _userRespository.Update(user);
            return Task.CompletedTask;
        }
    }
}
