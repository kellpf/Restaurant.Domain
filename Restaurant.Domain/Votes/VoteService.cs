using Domain.Votes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Votes
{
    public class VoteService : IVoteService
    {
        public Task Create(Vote vote)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int idVote)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vote>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Vote> FindById(int idVote)
        {
            throw new NotImplementedException();
        }

        public Task FindByUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public Task Update(Vote vote)
        {
            throw new NotImplementedException();
        }
    }
}
