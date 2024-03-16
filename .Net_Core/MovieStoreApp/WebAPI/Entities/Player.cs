﻿namespace WebAPI.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
