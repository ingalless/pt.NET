namespace PT.Models
{
    public class Congregation
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Speaker> Speakers { get; set; }
    }
}