using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class Movie // creating a movie classing. setting the values, data types and if null or not null
    {
        [Key]
        [Required]
        // these are all required fields
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        //the following three can be null per the ?
        public bool? Edited { get; set; }
        public string? Lent { get; set; }
        public string? Notes { get; set; }
    }
}
