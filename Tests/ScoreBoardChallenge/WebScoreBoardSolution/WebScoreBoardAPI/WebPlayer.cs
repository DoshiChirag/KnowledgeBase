namespace WebScoreBoardAPI
{
    public class WebPlayer
    {

        public DateOnly CreatedOn { get; set; }

        public Guid PlayerID { get; set; }

        public int Score { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

    }
}
