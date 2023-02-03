using Domain.Users;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using WebAPI.Controllers.Users.Mapper;
using WebAPI.Controllers.Users.Model;
using WebAPI.Shared.Model;

namespace WebAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<object>> FindAllUsers()
        {
            var users = await _service.FindAll();

            if (!users.Any())
                return NoContent();

            var usersConvert = UserMapper.ToControllerList(users);
            return Ok(new ResponseGeneric<List<UserResponse>>{ Success = true, Result = usersConvert });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<object>> FindUser(int id)
        {
            if (id < 0)
                return BadRequest();

            var user = await _service.FindById(id);
            if(user == null)
                return NotFound();

            var userConvert = UserMapper.ToController(user);
            return Ok(new ResponseGeneric<UserResponse>{ Success = true, Result = userConvert });
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateUser(CreateUserPayload userPayoad)
        {
            if (userPayoad == null)
                return BadRequest();
            

            var user = UserMapper.CreateToDomain(userPayoad);
            await _service.Create(user);

            return Ok(new ResponseGeneric<T>{ Success = true, Message = "Usuario criado com sucesso" });
        }

        [HttpPut]
        public async Task<ActionResult<object>> UploadUser(UpdateUserPayload userPayoad)
        {
            if (userPayoad == null)
                return BadRequest();

            var user = UserMapper.UploadToDomain(userPayoad);
            await _service.Update(user);

            return Ok(new ResponseGeneric<T>{ Success = true, Message = "Usuario alterado com sucesso" });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<object>> Delete(int id)
        {
            if (id < 0)
                return BadRequest();

            await _service.Delete(id);

            var resp = new ResponseGeneric<T>
            {
                Success = true,
                Message = "Usuario alterado com sucesso"
            };
            return Ok(resp);
        }

    }
}
