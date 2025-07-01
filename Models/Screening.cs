using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlixNow.Models
{
    public class Screening
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime ReleaseTime { get; set; }

        [Required]
        public int RunningTime { get; set; } // 单位：分钟

        [Required]
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [Required]
        public string Hall { get; set; }
    }
}
