namespace WebAPI.Controllers.Votes.Model
{
    public class VoteResponse
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdRestaurant { get; set; }
        public DateTime Date { get; set; }
    }
}
