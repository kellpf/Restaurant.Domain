
using Domain.Restaurants;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using WebAPI.Controllers.Restaurants.Mapper;
using WebAPI.Controllers.Restaurants.Model;
using WebAPI.Shared.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private readonly IRestaurantService _service;


        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<object>> FindAllRestaurants()
        {
            var restaurants = await _service.FindAll();

            if (!restaurants.Any())
                return NoContent();

            var restList = RestaurantMapper.ToControllerList(restaurants);
     
            return Ok(new ResponseGeneric<List<RestaurantResponse>>(){ Success = true, Result = restList });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<object>> FindRestaurant(int id)
        {
            if (id < 0)
                return BadRequest();
           
            var restaurant = await _service.FindById(id);
            if (restaurant == null)
                return NotFound();

            var respModel = RestaurantMapper.ToController(restaurant);
            return Ok(new ResponseGeneric<RestaurantResponse>(){ Success = true, Result = respModel });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGeneric<T>))]
        public async Task<ActionResult<object>> CreateRestaunt([FromBody]CreateRestaurantPayload restaurantPayload)
        {
            if (restaurantPayload == null)
                return BadRequest();

            var restaurant = RestaurantMapper.CreateToDomain(restaurantPayload);
            await _service.Create(restaurant);

            return Ok(new ResponseGeneric<T>{ Success = true, Message = "Restaurante adicionado com sucesso!" });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<object>> Delete(int id)
        {
            if (id < 0)
                return BadRequest();

            await _service.Delete(id);

            return Ok(new ResponseGeneric<T>() { Success = true, Message = "Restaurante excluido com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult<object>> Update(UpdateRestaurantPayload restaurant)
        {
            if (restaurant == null)
                return BadRequest();

            var rest = RestaurantMapper.UploadToDomain(restaurant);
            await _service.Update(rest);

            return Ok(new ResponseGeneric<T>(){ Success = true, Message = "Restaurante alterado com sucesso!" });
        }
    }
}
