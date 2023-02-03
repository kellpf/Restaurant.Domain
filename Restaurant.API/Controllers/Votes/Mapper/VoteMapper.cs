using Domain.Votes.Models;
using WebAPI.Controllers.Votes.Model;

namespace WebAPI.Controllers.Votes.Mapper
{
    public class VoteMapper
    {

        public static Vote CreateToDomain(CreateVotePayload votePayload)
        {
            return new()
            {
                IdUser = votePayload.IdUser,
                IdRestaurant = votePayload.IdRestaurant,
                Date = votePayload.Date
            };
        }

        public static Vote UploadToDomain(UpdateVotePayload votePayload)
        {
            return new()
            {
                Id = votePayload.Id,
                IdUser = votePayload.IdUser,
                IdRestaurant = votePayload.IdRestaurant,
                Date = votePayload.Date
            };
        }

        public static VoteResponse ToController(Vote vote)
        {
            return new()
            {
                Id = vote.Id,
                IdUser = vote.IdUser,
                IdRestaurant = vote.IdRestaurant,
                Date = vote.Date
            };
        }

        public static List<VoteResponse> ToControllerList(List<Vote> vote)
        {
            var list = new List<VoteResponse>();
            if (vote.Any())
                vote.ForEach(item =>
                {
                    list.Add(new()
                    {
                        Id = item.Id,
                        IdRestaurant = item.IdRestaurant,
                        IdUser = item.IdUser,
                        Date = item.Date
                    }
                    );
                }
            );
            return list;
        }
    }
}
