using Domain.Votes;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using WebAPI.Controllers.Votes.Mapper;
using WebAPI.Controllers.Votes.Model;
using WebAPI.Shared.Model;

namespace WebAPI.Controllers.Votes
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _service;

        public VoteController(IVoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<object>> FindAllVotes()
        {
            var votes = await _service.FindAll();

            if(!votes.Any())
                return NoContent();

            var votesConvert = VoteMapper.ToControllerList(votes);
            var resp = new ResponseGeneric<List<VoteResponse>>()
            {
                Success = true,
                Result = votesConvert
            };
            return Ok(resp);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<object>> FindVote(int id)
        {
            var vote = await _service.FindById(id);

            if (id < 0)
                return BadRequest();

            var votesConvert = VoteMapper.ToController(vote);
            var resp = new ResponseGeneric<VoteResponse>()
            {
                Success = true,
                Result = votesConvert
            };
            return Ok(resp);
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateVote(CreateVotePayload votePayload)
        {
            if (votePayload == null)
                return BadRequest();

            var vote = VoteMapper.CreateToDomain(votePayload);
            await _service.Create(vote);

            var resp = new ResponseGeneric<T>()
            {
                Success = true,
                Message = "Vote concluido com sucesso"
            };
            return Ok(resp);
        }

        [HttpPut]
        public async Task<ActionResult<object>> UpdateVote(UpdateVotePayload votePayload)
        {
            if (votePayload == null)
                return BadRequest();

            var vote = VoteMapper.UploadToDomain(votePayload);
            await _service.Update(vote);

            var resp = new ResponseGeneric<T>()
            {
                Success = true,
                Message = "Vote alterado com sucesso"
            };
            return Ok(resp);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<object>> DeleteVote(int id)
        {
            if (id < 0)
                return BadRequest();

            await _service.Delete(id);

            var resp = new ResponseGeneric<T>()
            {
                Success = true,
                Message = "Vote excluido com sucesso"
            };
            return Ok(resp);
        }
    }
}
