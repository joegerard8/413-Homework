using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mission6.Models;

namespace Mission6.Models
{
    public class Category // category class. Only contains two fields, id and name. very simple. 
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public ICollection<Movie> Movies
        {
            get; set;

        }
    }
}
