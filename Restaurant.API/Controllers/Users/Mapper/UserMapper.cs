using Domain.Users.Models;
using WebAPI.Controllers.Users.Model;

namespace WebAPI.Controllers.Users.Mapper
{
    public static class UserMapper
    {
        public static User CreateToDomain(CreateUserPayload userPayload)
        {
            return new()
            {
                Name = userPayload.Name,
                Password = userPayload.Password,
                Email = userPayload.Email
            };
        }

        public static User UploadToDomain(UpdateUserPayload userPayload)
        {
            return new()
            {
                Id = userPayload.Id,
                Name = userPayload.Name,
                Password = userPayload.Password,
                Email = userPayload.Email,
                Status = userPayload.Status
            };
        }

        public static UserResponse ToController(User user)
        {
            return new()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Status = user.Status
            };
        }

        public static List<UserResponse> ToControllerList(List<User> users)
        {
            var list = new List<UserResponse>();
            if (users.Any())
                users.ForEach(item =>
                {
                    list.Add(new()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email,
                        Status = item.Status
                    });
                }
            );
            return list;
        }
    }
}
