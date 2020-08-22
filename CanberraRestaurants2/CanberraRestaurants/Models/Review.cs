using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanberraRestaurants.Models
{
    public class Review
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; } //manager or user

        [Required]
        public string Heading { get; set; } //requires input from user to save

        [Required]
        public string Restaurant { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string Rating { get; set; }

        public int Agree { get; set; }

        public int Disagree { get; set; }

        public bool IsClicked { get; set; }
    }
}
