namespace WebAPI.Entities
{
    public class Order : BaseEntity
    {
        public double Price { get; set; }

        public int CustomerId { get; set; }
        public int MovieId { get; set; }

        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
    }
}
