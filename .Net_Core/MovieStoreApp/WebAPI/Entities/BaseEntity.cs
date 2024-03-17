﻿namespace WebAPI.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
