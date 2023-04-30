namespace PT.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int CongregationId { get; set; }

        public Congregation Congregation { get; set; }


    }
}
