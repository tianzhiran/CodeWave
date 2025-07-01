using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FlixNow.Models

{
    // This model represents a movie showtime in the database
    public class Showtime
    {
        public int Id { get; set; } // Primary key

        [Required]
        public DateTime StartTime { get; set; } // Show start time

        [Required]
        public int MovieId { get; set; } // Foreign key to Movie

        [ForeignKey("MovieId")]

        public Movie Movie { get; set;} // Navigation property
        //Required(ErrorMessage = "Hall is required.")]
        public string Hall { get; set; } // Hall name or number
    }
}