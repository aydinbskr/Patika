namespace WebAPI.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? RefreshTokenExpireDate { get; set; }

        public ICollection<MovieType> FavoriteMovieTypes { get; set; }
    }
}
