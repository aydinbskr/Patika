namespace WebAPI.Entities
{
    public class CustomerFavoriteType:BaseEntity
    {
        public int MovieTypeId { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public MovieType MovieType { get; set; }
    }
}
