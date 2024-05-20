using System.ComponentModel.DataAnnotations;

namespace AdoPractice1.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter department name")]
        public string Name { get; set; }
    }
}
