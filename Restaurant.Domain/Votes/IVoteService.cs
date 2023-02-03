using Domain.Votes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Votes
{
    public interface IVoteService
    {
        Task<List<Vote>> FindAll();
        Task<Vote> FindById(int idVote);
        Task FindByUser(int idUser);
        Task Create(Vote vote);
        Task Update(Vote vote);
        Task Delete(int idVote);
        // delete??
    }
}
