using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoPractice1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter employee name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter employee pin")]
        public string Pin { get; set; }

        public bool IsActive { get; set; } = true;
        [Required(ErrorMessage ="Please choose department id")]
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department? Department { get; set; }


    }
}
