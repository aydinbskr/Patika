namespace WebAPI.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public int MovieTypeId { get; set; }
        public double Price { get; set; }
        public int DirectorId { get; set; }
        public ICollection<Player> Players { get; set; }
        public Director Director { get; set; }
        public MovieType MovieType { get; set; }
    }
}
