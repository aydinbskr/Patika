namespace WebAPI.Entities
{
    public class Director : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
