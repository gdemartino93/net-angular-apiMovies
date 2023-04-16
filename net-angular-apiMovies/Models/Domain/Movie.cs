﻿using System.ComponentModel.DataAnnotations;

namespace net_angular_apiMovies.Models.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Vote { get; set; }
        public int CategoryId { get; set; }


    }
}