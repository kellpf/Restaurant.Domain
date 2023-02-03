using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Votes.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdRestaurant { get; set; }
        public DateTime Date { get; set; }
    }
}
