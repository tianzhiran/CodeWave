using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;



namespace FlixNow.Models
{
    // This model represents a movie entity in the database
    public class Movie
    {
        public int Id { get; set; }  // Primary key, auto-increment

        [Required]
        public string Title { get; set; } // Movie title

        public string Description { get; set; } // Brief introduction

        public string PosterUrl { get; set; } // Movie poster image link

        public string Genre { get; set; } // Genre (e.g. action, drama)

        public double Rating { get; set; } // Movie rating, e.g. 7.5|
        public ICollection<Screening> Screenings { get; set; }
    }
}
