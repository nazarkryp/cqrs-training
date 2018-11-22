namespace CqrsTraining.Domain.Entities
{
    public class Media
    {
        public int MediaId { get; set; }

        public string Url { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
