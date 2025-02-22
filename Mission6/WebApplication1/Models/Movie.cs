using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Mission6.Models
{
    public class Movie // creating a movie classing. setting the values, data types and if null or not null
    {
        [Key]
        [Required]
        // these are all required fields
        public int MovieId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")] //creating a foreign key relationship with category table
        [ValidateNever] //prevents the model from validating the category, as it isn't actually set in the db, only the categoryid is 
        public Category Category { get; set; }

        [Required(ErrorMessage = "Title is required.")] // need a movie title to be able to submit
        public string Title { get; set; }

        [Required]
        [Range(1888, 2025, ErrorMessage = "You must enter a valid year")] //Movie release year must be between 1888 and the current year
        public int Year { get; set; }

        // anything below that uses a question mark after the data type means it isn't a required field
        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited field is required.")] //error messahe to make sure they include if edited or not
        public int Edited { get; set; }

        public string? LentTo { get; set; }
        public string? Notes { get; set; }

        [Required(ErrorMessage = "CopiedToPlex field is required.")] //error message to stop submit unless copied to plex is included
        public int CopiedToPlex { get; set; }
    }

}
